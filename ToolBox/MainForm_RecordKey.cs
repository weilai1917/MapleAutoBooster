using MapleAutoBooster.Abstract;
using MapleAutoBooster.ToolBox;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private Stopwatch RecordStopWatch = new Stopwatch();

        private void BtnRecordKey_Click(object sender, EventArgs e)
        {
            if (this.BtnRecordKey.Tag == null)
            {
                HookKey = new GlobalKeyboardHook();
                HookKey.KeyDown += RecordKeyDownAction;
                HookKey.KeyUp += RecordKeyUpAction;
                RecordList = new List<RecordKeyData>();
                RecordStopWatch.Start();
                this.BtnRecordKey.Tag = true;
                this.BtnRecordKey.Text = "停止录制";
            }
            else
            {

                #region 把RecordList专程一条记录，进行build
                ServiceConfig config = new ServiceConfig();
                config.Guid = Guid.NewGuid().ToString();
                config.ServiceTypeId = "MapleAutoBooster.Service.AutoKeyService";
                config.ServiceName = "自动按键";
                config.ServicePolicy = Abstract.ServicePolicyEnum.Once;
                config.ServiceDescription = $"总时长：{RecordList.Sum(x => x.Wait) / 1000}s，动作数：{RecordList.Count}";
                var opObject1 = new OperateObject();
                opObject1.OperateId = Guid.NewGuid().ToString();
                opObject1.OperateTarget = "1";
                opObject1.Operations = new List<IOperation>();
                foreach (var item in RecordList)
                {
                    opObject1.Operations.Add(new Operation($"PressKey[{item.Key},{item.Action},{item.Wait}]"));
                }
                var opObject0 = new OperateObject();
                opObject0.OperateId = Guid.NewGuid().ToString();
                opObject0.OperateTarget = "0";
                opObject0.Operations = new List<IOperation>();
                opObject0.Operations.Add(new Operation($"LockMapleWindow[]"));
                config.Operations = JsonConvert.SerializeObject(new List<OperateObject>() { opObject0, opObject1 });
                this.MapleConfig.ServiceData.Add(config);
                this.MapleConfig.Save();
                #endregion

                this.MapleConfig.Reload();
                this.ReloadServices();

                this.BtnRecordKey.Text = "录制键盘";
                this.BtnRecordKey.Tag = null;

                HookKey.KeyDown -= RecordKeyDownAction;
                HookKey.KeyUp -= RecordKeyUpAction;
                HookKey = null;
                GC.Collect();
            }
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

        #region 全局热键

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        //如果函数执行成功，返回值不为0。  
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。  
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄  
            int id,                     //定义热键ID（不能与其它ID重复）            
            KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效  
            Keys vk                     //定义热键的内容  
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄  
            int id                      //要取消热键的ID  
            );

        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）  
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        /// <summary>  
        /// 注册热键  
        /// </summary>  
        /// <param name="hwnd">窗口句柄</param>  
        /// <param name="hotKey_id">热键ID</param>  
        /// <param name="keyModifiers">组合键</param>  
        /// <param name="key">热键</param>  
        public static void RegKey(IntPtr hwnd, int hotKey_id, KeyModifiers keyModifiers, Keys key)
        {
            try
            {
                if (!RegisterHotKey(hwnd, hotKey_id, keyModifiers, key))
                {
                    if (Marshal.GetLastWin32Error() == 1409) { MessageBox.Show("热键被占用 ！"); }
                    else
                    {
                        MessageBox.Show("注册热键失败！");
                    }
                }
            }
            catch (Exception) { }
        }
        /// <summary>  
        /// 注销热键  
        /// </summary>  
        /// <param name="hwnd">窗口句柄</param>  
        /// <param name="hotKey_id">热键ID</param>  
        public static void UnRegKey(IntPtr hwnd, int hotKey_id)
        {
            //注销Id号为hotKey_id的热键设定  
            UnregisterHotKey(hwnd, hotKey_id);
        }

        private const int WM_HOTKEY = 0x312; //窗口消息-热键  
        private const int WM_CREATE = 0x1; //窗口消息-创建  
        private const int WM_DESTROY = 0x2; //窗口消息-销毁  
        private const int F1 = 0x3572; //热键ID  
        private const int F2 = 0x3576; //热键ID  
        private const int F3 = 0x3578; //热键ID 
        private const int F8 = 0x3588; //热键ID 
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键ID  
                    switch (m.WParam.ToInt32())
                    {
                        case F1: //热键ID  
                            if (!Start)
                            {
                                this.Text = "(๑•ᴗ•๑)启动中";
                                this.Start = true;
                                this.MapleConfig.Save();
                                this.StartAllService();
                            }
                            else
                            {
                                this.Text = "冒险发射器";
                                this.Start = false;
                                this.LockAllControl(true);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建  
                    RegKey(Handle, F1, KeyModifiers.None, Keys.F1);
                    //RegKey(Handle, F8, KeyModifiers.None, Keys.F8);
                    break;
                case WM_DESTROY: //窗口消息-销毁  
                    UnRegKey(Handle, F1); //销毁热键  
                    break;
                default:
                    break;
            }
        }

        #endregion
    }

    public class RecordKeyData
    {
        public Keys Key { get; set; }
        public int Action { get; set; }
        public long Wait { get; set; }

        public RecordKeyData(Keys key, int action, long wait)
        {
            this.Key = key;
            this.Action = action;
            this.Wait = wait;
        }

    }
}
