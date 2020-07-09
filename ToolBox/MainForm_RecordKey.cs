using MapleAutoBooster.Abstract;
using MapleAutoBooster.ToolBox;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    public partial class MainForm
    {
        private GlobalKeyboardHook HookKey;
        private List<Tuple<Keys, int, long>> RecordList;
        private Stopwatch RecordStopWatch = new Stopwatch();

        private void BtnRecordKey_Click(object sender, EventArgs e)
        {
            if (this.BtnRecordKey.Tag == null)
            {
                HookKey = new GlobalKeyboardHook();
                HookKey.KeyDown += RecordKeyDownAction;
                HookKey.KeyUp += RecordKeyUpAction;
                RecordList = new List<Tuple<Keys, int, long>>();
                RecordStopWatch.Start();
                this.BtnRecordKey.Tag = true;
                this.BtnRecordKey.Text = "停止录制";
            }
            else
            {
                //把RecordList专程一条记录，进行build
                ServiceConfig config = new ServiceConfig();
                config.Guid = Guid.NewGuid().ToString();
                config.ServiceTypeId = "MapleAutoBooster.Service.AutoKeyService";
                config.ServiceName = "自动按键";
                config.ServicePolicy = Abstract.ServicePolicyEnum.Once;
                config.ServiceDescription = DateTime.Now.ToString();
                var opObject = new OperateObject();
                opObject.OperateId = Guid.NewGuid().ToString();
                opObject.OperateTarget = "1";
                opObject.Operations = new List<IOperation>();
                foreach (var item in RecordList)
                {
                    opObject.Operations.Add(new Operation($"PressKey[{item.Item1},{item.Item2},{item.Item3.ToString()}]"));
                }
                config.Operations = JsonConvert.SerializeObject(new List<OperateObject>() { opObject });
                this.MapleConfig.ServiceData.Add(config);
                this.MapleConfig.Save();
                this.MapleConfig.Reload();
                this.ReloadServices();

                this.BtnRecordKey.Text = "录制键盘";
                this.BtnRecordKey.Tag = null;
                HookKey = null;
                GC.Collect();
            }
        }

        public void RecordKeyDownAction(object sender, KeyEventArgs e)
        {
            RecordStopWatch.Stop();
            RecordList.Add(new Tuple<Keys, int, long>(e.KeyData, 0, RecordList.Count == 0 ? 0 : RecordStopWatch.ElapsedMilliseconds));
            RecordStopWatch.Restart();
        }

        public void RecordKeyUpAction(object sender, KeyEventArgs e)
        {
            RecordStopWatch.Stop();
            RecordList.Add(new Tuple<Keys, int, long>(e.KeyData, 1, RecordList.Count == 0 ? 0 : RecordStopWatch.ElapsedMilliseconds));
            RecordStopWatch.Restart();
        }
    }
}
