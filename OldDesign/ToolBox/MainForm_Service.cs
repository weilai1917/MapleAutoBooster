using MapleAutoBooster.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleAutoBooster
{
    //public class MainForm
    //{
        //private void StartAllService()
        //{
        //    LockAllControl(!Start);
        //    Task.Run(() =>
        //    {
        //        this.LogTxt($"----开始并行执行任务，任务数量：{this.MapleConfig.ServiceData.Where(x => x.IsRun).Count()}个----", EnumColor.Blue);
        //        Parallel.ForEach(this.MapleConfig.ServiceData.Where(x => x.IsRun), new Action<ServiceConfig>(t =>
        //        {
        //            ServiceConfig config = t;
        //            Queue<ServiceConfig> queueService = new Queue<ServiceConfig>();
        //            AbstractBoosterService runService = null;
        //            do
        //            {
        //                if (queueService.Count > 0)
        //                    config = queueService.Dequeue();

        //                this.LogTxt($"初始化服务规则：“{config.ServiceDescription}”，请稍后。");
        //                runService = ServiceBuilder.ReBuildService(config, true);
        //                var runOperations = runService.Operations;

        //                var operations = runOperations.GroupBy(x => x.OperateTarget).OrderBy(x => x.Key);
        //                this.LogTxt($"初始化任务：“{config.ServiceDescription}”完成，有{operations.Count()}个操作进行。策略：{runService.ServicePolicy}");
        //                try
        //                {
        //                    this.LogStatus(runService.ServiceDescription);
        //                    //分别循环 1，2，3 个方框内服务。
        //                    foreach (var item in operations)
        //                    {
        //                        do
        //                        {
        //                            foreach (var operation in item.SelectMany(x => x.Operations))
        //                            {
        //                                operation.HandleOperationMethod(runService, (m, p) =>
        //                                {
        //                                    operation.ExeuteOperationMethod(runService, m, p);
        //                                });

        //                                int i = 0;
        //                                while (Stop && Start)
        //                                {
        //                                    if (i == 0) this.LogTxt($"{runService.ServiceDescription}已经暂停，请停止或恢复暂停。", EnumColor.Red);
        //                                    Thread.Sleep(100);
        //                                    i++;
        //                                }
        //                            }
        //                        } while (runService.ServicePolicy == ServicePolicyEnum.Loop && item.Key == "1" && Start);
        //                    }
        //                    //遍历循环已经结束
        //                    this.LogTxt($"{runService.ServiceDescription}已经执行完毕，继续执行下一个服务。", EnumColor.Blue);
        //                    if (runService.AnotherOperations != null && runService.AnotherOperations.Count > 0)
        //                    {
        //                        foreach (var item in runService.AnotherOperations)
        //                        {
        //                            queueService.Enqueue(this.MapleConfig.ServiceData.First(x => x.Guid == item));
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    this.LogTxt($"异常终止了服务，{runService.ServiceDescription}，错误信息{ex.Message}", EnumColor.Red);
        //                    runService = null;
        //                }
        //                if (!Start)
        //                {
        //                    queueService.Clear();
        //                    break;
        //                }
        //            } while (queueService.Count > 0);
        //        }));
        //    });
        //}

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // MainForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "MainForm";
        //    this.Load += new System.EventHandler(this.MainForm_Load);
        //    this.ResumeLayout(false);

        //} 
    //}
}
