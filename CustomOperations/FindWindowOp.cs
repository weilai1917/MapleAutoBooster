using MapleAutoBooster.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.CustomOperations
{
    /// <summary>
    /// 查找目标窗口
    /// </summary>
    public class FindWindowOp : AbstractOperation
    {
        public override string OperationKey { set => value = "B8D93388-5C97-44C1-8798-F77FC1A4E5C3"; }

        public FindWindowOp()
        {
            this.operationName = "查找窗口";
            this.operationDescription = "根据提供的窗口名，找到Top窗口，并返回窗口对象";
        }

        public FindWindowOp(string id, string od)
            : this()
        {
            this.operationId = id;
            this.operationDescription = od;
        }

        public override object Do(string p)
        {
            JObject param = JsonConvert.DeserializeObject<JObject>(p);
            string lpClassName = param["lpClassName"].ToString();
            string lpWindowName = param["lpWindowName"].ToString();
            return FindWindow(lpClassName, lpWindowName);
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public override IOperation CreateInstance()
        {
            return new FindWindowOp();
        }
    }
}
