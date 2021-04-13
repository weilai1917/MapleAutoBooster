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
    public class PressDirectKeyOp : AbstractOperation
    {
        public override string OperationKey { get { return "4687A577-1988-44DB-9D15-8C99DBE19DEA1"; } }

        public PressDirectKeyOp()
        {
            this.operationName = "自动按方向键";
            this.operationDescription = "根据按方向键值进行单个键值敲击";
        }

        public PressDirectKeyOp(string id, string od)
            : this()
        {
            this.operationId = id;
            this.operationDescription = od;
        }

        public override IOperation CreateInstance()
        {
            return new PressDirectKeyOp();
        }

        public override object Do(string p)
        {
            JObject param = JsonConvert.DeserializeObject<JObject>(p);
            string pressKey = param["pressKey"].ToString();
            int pressAction = Convert.ToInt32(param["pressAction"]);
            int pressWait = Convert.ToInt32(param["pressWait"]);

            Keys key = (Keys)Enum.Parse(typeof(Keys), pressKey);
            keybd_event((byte)key, (byte)(Keys)MapVirtualKey((uint)key, 0), pressAction, 0);

            Thread.Sleep(pressWait);
            return true;
        }

        #region 按键API
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern int MapVirtualKey(uint Ucode, uint uMapType);
        #endregion
    }
}
