using MapleAutoBooster.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster.CustomOperations
{
    /// <summary>
    /// 自动按操作键
    /// </summary>
    public class PressActionKeyOp : AbstractOperation
    {
        private const string tarKey = "tarWindow";
        public override string OperationKey
        {
            get { return "CC5049BA-7607-44EE-987A-21BD79EC7C01"; }
        }

        public PressActionKeyOp()
        {
            this.operationName = "自动按键";
            this.operationDescription = "根据按键值进行单个键值敲击";
        }

        public PressActionKeyOp(string id, string od)
            : this()
        {
            this.operationId = id;
            this.operationDescription = od;
        }

        public override IOperation CreateInstance()
        {
            return new PressActionKeyOp();
        }

        public override object Do(string p)
        {
            JObject param = JsonConvert.DeserializeObject<JObject>(p);
            string pressKey = param["pressKey"].ToString();
            int pressAction = Convert.ToInt32(param["pressAction"]);
            int pressWait = Convert.ToInt32(param["pressWait"]);

            IntPtr tarWindow;
            if (ThreadOptions == null)
            {
                tarWindow = GetForegroundWindow();
            }
            else
            {
                var threadOption = ThreadOptions.Value;
                tarWindow = (threadOption != null && threadOption.ContainsKey(tarKey)) ? (IntPtr)threadOption[tarKey] : IntPtr.Zero;
            }

            Keys key = (Keys)Enum.Parse(typeof(Keys), pressKey);
            PostMessage(tarWindow, pressAction, (int)key, MakeKeyLparam((int)key, pressAction));

            Thread.Sleep(pressWait);
            return true;
        }

        #region 按键API
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int MapVirtualKey(uint Ucode, uint uMapType);
        private const int WM_KEYUP = 0x101;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private int MakeKeyLparam(int VirtualKey, int flag)
        {
            string s;
            string Firstbyte;
            if (WM_KEYDOWN == flag)
                Firstbyte = "00";
            else
                Firstbyte = "C0";
            int Scancode;
            Scancode = MapVirtualKey((uint)VirtualKey, 0);
            string Secondebyte = "00" + string.Format("{0:X}", Scancode);
            Secondebyte = Secondebyte.Substring(Secondebyte.Length - 2, 2);
            s = Firstbyte + Secondebyte + "0001";
            return Convert.ToInt32(s, 16);
        }

        private int MakeDirKeyLparam(int VirtualKey, int flag)
        {
            string s;
            string Firstbyte;
            if (WM_KEYDOWN == flag)
                Firstbyte = "41";
            else
                Firstbyte = "C1";
            int Scancode;
            Scancode = MapVirtualKey((uint)VirtualKey, 0);
            string Secondebyte = "00" + string.Format("{0:X}", Scancode);
            Secondebyte = Secondebyte.Substring(Secondebyte.Length - 2, 2);
            s = Firstbyte + Secondebyte + "0001";
            return Convert.ToInt32(s, 16);
        }

        #endregion
    }
}
