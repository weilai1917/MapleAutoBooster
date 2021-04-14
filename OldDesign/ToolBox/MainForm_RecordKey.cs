using MapleAutoBooster.Abstract;
using MapleAutoBooster.ToolBox;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    public partial class MainForm
    {
        private GlobalKeyboardHook HookKey = null;
        private List<RecordKeyData> RecordList;
        private Dictionary<int, string> HotKeyPairs = new Dictionary<int, string>();
        private Dictionary<int, MethodInfo> HotKeyAction = new Dictionary<int, MethodInfo>();
        private Stopwatch RecordStopWatch = new Stopwatch();

        #region API

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        #endregion

        private void ReloadHotKeys()
        {
            if (HotKeyPairs != null)
            {
                foreach (var item in HotKeyPairs)
                {
                    UnregisterHotKey(this.Handle, item.Key);
                    GlobalDeleteAtom((uint)item.Key);
                }
                HotKeyPairs.Clear();
                HotKeyAction.Clear();
            }

            if (this.MapleConfig.HotKeys == null)
                return;

            foreach (var item in this.MapleConfig.HotKeys)
            {
                if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value))
                {
                    continue;
                }

                int hotkeyid = (int)GlobalAddAtom(System.Guid.NewGuid().ToString());
                var r = RegisterHotKey(this.Handle, hotkeyid, KeyModifiers.None, (Keys)Enum.Parse(typeof(Keys), item.Value));
                if (r)
                {
                    HotKeyPairs.Add(hotkeyid, item.Key);
                    HotKeyAction.Add(hotkeyid, this.GetType().GetMethod(item.Key));
                }
                else
                {
                    this.LogTxt($"{item.Value}热键注册占用，注册失败。");
                }
            }
        }

        private const int WM_HOTKEY = 0x312;
        private const int WM_CREATE = 0x1;
        private const int WM_DESTROY = 0x2;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    var paramKey = m.WParam.ToInt32();
                    if (HotKeyAction.ContainsKey(paramKey) && HotKeyAction[paramKey] != null)
                    {
                        HotKeyAction[paramKey].Invoke(this, null);
                    }
                    break;
                case WM_DESTROY:
                    if (HotKeyPairs != null)
                    {
                        foreach (var item in HotKeyPairs)
                        {
                            UnregisterHotKey(this.Handle, item.Key);
                            GlobalDeleteAtom((uint)item.Key);
                        }
                        HotKeyPairs.Clear();
                        HotKeyAction.Clear();
                    }
                    break;
                default:
                    break;
            }
        }

        public void HotKeyServiceBoot()
        {
            if (!Start)
            {
                this.Text = "(๑•ᴗ•๑)启动中";
                this.Start = true;
                this.Stop = false;
                this.MapleConfig.Save();
                //this.StartAllService();
            }
            else
            {
                this.Text = "冒险发射器";
                this.Start = false;
                this.Stop = false;
                this.LockAllControl(true);
            }
        }

        public void HotKeyKeyRecord()
        {
            if (Start)
            {
                MessageBox.Show("请先停止服务运行！", "发射！");
                return;
            }

            if (string.IsNullOrEmpty(CurrGroupKey))
            {
                MessageBox.Show("请先添加服务分组。", "发射！");
                return;
            }
            if (this.BtnRecordKey.Tag == null)
            {
                HookKey = new GlobalKeyboardHook((Keys)Enum.Parse(typeof(Keys), this.MapleConfig.HotKeyKeyRecord));
                HookKey.KeyDown += RecordKeyDownAction;
                HookKey.KeyUp += RecordKeyUpAction;

                RecordList = new List<RecordKeyData>();
                RecordStopWatch.Start();

                this.BtnRecordKey.Tag = true;
                this.LogTxt("开始录制键盘。");
                this.LogStatus("开始录制键盘。");
                this.LockAllControl(false);

                timer_Record.Start();
            }
            else
            {
                this.timer_Record.Stop();

                this.MapleConfig.ServiceData.Add(ServiceBuilder.BuildKeyRecord(CurrGroupKey, RecordList));
                this.MapleConfig.Save();

                this.MapleConfig.Reload();
                this.ReloadServices();

                this.BtnRecordKey.Tag = null;
                this.LogTxt("录制键盘已经停止。");
                this.LogStatus("录制键盘已经停止。");
                this.LockAllControl(true);

                HookKey.KeyDown -= RecordKeyDownAction;
                HookKey.KeyUp -= RecordKeyUpAction;
                HookKey = null;
                GC.Collect();
            }
        }

        private void Timer_Record_Tick(object sender, EventArgs e)
        {
            this.LogStatus($"当前已录制：{this.timer_Record.Interval / 1000}秒");
        }

        private Timer timer_Record = new Timer();

        public void HotKeyServiceStop()
        {
            Stop = !Stop;
        }

        public void RecordKeyDownAction(object sender, KeyEventArgs e)
        {
            RecordStopWatch.Stop();
            if (RecordList.Count > 0)
                RecordList[RecordList.Count - 1].Wait = RecordStopWatch.ElapsedMilliseconds;
            RecordList.Add(new RecordKeyData(e.KeyData, 0, 0));
            RecordStopWatch.Restart();
        }

        public void RecordKeyUpAction(object sender, KeyEventArgs e)
        {
            RecordStopWatch.Stop();
            if (RecordList.Count > 0)
                RecordList[RecordList.Count - 1].Wait = RecordStopWatch.ElapsedMilliseconds;
            RecordList.Add(new RecordKeyData(e.KeyData, 1, 0));
            RecordStopWatch.Restart();
        }
    }
}
