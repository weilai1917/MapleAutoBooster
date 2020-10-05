using MapleAutoBooster.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleAutoBooster
{
    public partial class MainForm
    {
        private void StartAllService()
        {
            LockAllControl(!Start);
            List<string> selRows = new List<string>();
            Task.Run(() =>
            {
                this.LogTxt($"开始并发执行任务，任务数量：{this.MapleConfig.ServiceData.Where(x => x.IsRun).Count()}");
                Parallel.ForEach(this.MapleConfig.ServiceData.Where(x => x.IsRun), new Action<ServiceConfig>(t =>
                {
                    Queue<ServiceConfig> queueService = new Queue<ServiceConfig>();
                    AbstractBoosterService runService = null;
                    do
                    {
                        queueService.Enqueue(t);
                        this.LogTxt($"初始化服务规则：“{t.ServiceDescription}”，请稍后。");
                        runService = ServiceBuilder.ReBuildService(t, true);
                        var runOperations = runService.Operations;

                        var operations = runOperations.GroupBy(x => x.OperateTarget).OrderBy(x => x.Key);
                        this.LogTxt($"初始化任务：“{t.ServiceDescription}”完成，有{operations.Count()}个操作进行。策略：{runService.ServicePolicy}");
                        try
                        {
                            this.LogStatus(runService.ServiceDescription);
                            //分别循环 1，2，3 个方框内服务。
                            foreach (var item in operations)
                            {
                                do
                                {
                                    foreach (var operation in item.SelectMany(x => x.Operations))
                                    {
                                        operation.HandleOperationMethod(runService, (m, p) =>
                                        {
                                            operation.ExeuteOperationMethod(runService, m, p);
                                        });

                                        if (!Start)
                                        {
                                            break;
                                        }

                                        if (Stop)
                                        {
                                            this.LogTxt($"{runService.ServiceDescription}已经暂停，请停止或恢复暂停");
                                        }

                                        while (Stop)
                                        {
                                            Thread.Sleep(1);
                                        }
                                    }
                                } while (runService.ServicePolicy == ServicePolicyEnum.Loop && item.Key == "1" && Start);
                            }
                            queueService.Dequeue();
                            //遍历循环已经结束
                            this.LogTxt($"{runService.ServiceDescription}已经执行完毕，继续执行下一个服务。");
                            if (runService.AnotherOperations != null && runService.AnotherOperations.Count > 0)
                            {
                                foreach (var item in runService.AnotherOperations)
                                {
                                    //压入队列，进行循环。
                                    queueService.Enqueue(this.MapleConfig.ServiceData.First(x => x.Guid == item));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.LogTxt($"异常终止了服务，{runService.ServiceDescription}，错误信息{ex.Message}");
                            runService = null;
                        }
                        if (!Start)
                        {
                            break;
                        }
                    } while (queueService.Count > 0);
                }));
            });
        }
    }
}
