using MapleAutoBooster.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster.Service
{
    public class AutoKeyService : AbstractService
    {
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

        public override void SetDefaultOperations()
        {
            List<Tuple<string, string>> defaultOp = new List<Tuple<string, string>>();
            defaultOp.Add(new Tuple<string, string>("0", "LockMapleWindow"));
            defaultOp.Add(new Tuple<string, string>("1", "PressKey-A,down,20"));
            defaultOp.Add(new Tuple<string, string>("1", "PressMouseKey-MOVE,1,100,92,355"));
            defaultOp.Add(new Tuple<string, string>("1", "PressMouseKey-Left,1,20,0,0"));
            defaultOp.Add(new Tuple<string, string>("1", "PressDirectionKey-Left,down,20"));

            foreach (var operations in defaultOp.GroupBy(x => x.Item1))
            {
                var opObject = new OperateObject();
                opObject.OperateId = Guid.NewGuid().ToString();
                opObject.OperateTarget = operations.Key;
                opObject.Operations = new List<IOperation>();
                foreach (var item in operations)
                {
                    opObject.Operations.Add(new Operation(item.Item2));
                }
                this.Operations.Add(opObject);
            }
        }

        [DllImport("user32.dll")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_MOVE = 0x0001; //移动鼠标
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下
        public const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下
        public const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        #endregion

        private IntPtr MapleWindow = IntPtr.Zero;

        public string PressKey(string pressKey)
        {
            string[] keyparam = pressKey.Split(',');
            if (keyparam.Length < 3)
                return $"无法识别的按键";

            var keyTemp = keyparam[0];
            var keyAction = keyparam[1];
            var keyTime = keyparam[2];
            Keys key = (Keys)Convert.ToChar(keyTemp.ToUpperInvariant());
            var action = this.GetKeyAction(keyAction);
            if (this.Runtime)
            {
                PostMessage(MapleWindow, action.Item2, (int)key, MakeKeyLparam((int)key, action.Item2));

                var waitTime = Convert.ToInt32(keyTime);
                if (waitTime < 0)
                {
                    Random t = new Random();                   
                    waitTime = t.Next(50, 100);
                }
                Thread.Sleep(waitTime);
            }

            return $"{action.Item1}键{key.ToString()},{keyTime}ms";
        }

        public string PressRandomKey(string wait)
        {
            var keyTime = Convert.ToString(wait);
            Random randomKey = new Random();
            Keys key = (Keys)Convert.ToChar(randomKey.Next(48, 57));
            if (this.Runtime)
            {
                PostMessage(MapleWindow, WM_KEYDOWN, (int)key, MakeKeyLparam((int)key, WM_KEYDOWN));
                PostMessage(MapleWindow, WM_KEYUP, (int)key, MakeKeyLparam((int)key, WM_KEYUP));
                Thread.Sleep(Convert.ToInt32(keyTime));
            }
            return $"随机按键，{keyTime}ms";
        }

        public string PressDirectionKey(string direct)
        {
            string[] keyparam = direct.Split(',');
            if (keyparam.Length < 3)
                return $"无法识别的按键";

            var keyTemp = keyparam[0];
            var keyAction = keyparam[1];
            var keyTime = keyparam[2];
            byte key = (byte)Keys.Left;
            switch (keyTemp.ToUpperInvariant())
            {
                case "LEFT":
                    key = (byte)Keys.Left;
                    break;
                case "RIGHT":
                    key = (byte)Keys.Right;
                    break;
                case "UP":
                    key = (byte)Keys.Up;
                    break;
                case "DOWN":
                    key = (byte)Keys.Down;
                    break;
                default:
                    break;
            }
            byte machinekey = (byte)(Keys)MapVirtualKey((uint)key, 0);
            var action = this.GetDirectAction(keyAction);
            if (this.Runtime)
            {
                keybd_event(key, machinekey, action.Item2, 0);
                Thread.Sleep(Convert.ToInt32(keyTime));
            }

            return $"{action.Item1}键{key.ToString()},{keyTime}ms";
        }

        public string PressMouseKey(string mouseAction)
        {
            string[] keyparam = mouseAction.Split(',');
            if (keyparam.Length < 3)
                return $"无法识别的按键";

            var keyTemp = keyparam[0];
            var keyAction = keyparam[1];            
            var keyTime = keyparam[2];
            var keyDirectX = keyparam[3];
            var keyDirectY = keyparam[4];
            int x = 0, y = 0;
            x = Convert.ToInt32(keyDirectX);
            y = Convert.ToInt32(keyDirectY);
            var key = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
            switch (keyTemp.ToUpperInvariant())
            {
                case "MOVE":
                    key = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
                    break;
                case "LEFT":
                    key = MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP;
                    break;
                case "RIGHT":
                    key = MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP;
                    break;
                default:
                    break;
            }
            if (this.Runtime)
            {
                mouse_event(key, x * 65536 / 1920, y * 65536 / 1080, 0, 0);
                if (keyAction == "2")
                    mouse_event(key, x * 65536 / 1920, y * 65536 / 1080, 0, 0);
                Thread.Sleep(Convert.ToInt32(keyTime));
            }
            return $"鼠标操作";
        }

        public string LockMapleWindow()
        {
            MapleWindow = FindWindow("MapleStoryClass", "MapleStory");
            return "锁定冒险岛窗口";
        }

        private Tuple<string, int> GetKeyAction(string action)
        {
            string actionName = string.Empty;
            int actionValue = WM_KEYDOWN;
            switch (action.ToUpperInvariant())
            {
                case "UP":
                    actionName = "抬起";
                    actionValue = WM_KEYUP;
                    break;
                case "DOWN":
                    actionName = "按下";
                    actionValue = WM_KEYDOWN;
                    break;
                default:
                    break;
            }
            return new Tuple<string, int>(actionName, actionValue);
        }

        private Tuple<string, int> GetDirectAction(string action)
        {
            string actionName = string.Empty;
            int actionValue = 0;
            switch (action.ToUpperInvariant())
            {
                case "UP":
                    actionName = "抬起";
                    actionValue = 2;
                    break;
                case "DOWN":
                    actionName = "按下";
                    actionValue = 0;
                    break;
                default:
                    break;
            }
            return new Tuple<string, int>(actionName, actionValue);
        }

    }
}
