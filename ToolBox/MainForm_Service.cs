using MapleAutoBooster.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    this.LogTxt($"初始化服务规则：“{t.ServiceDescription}”，请稍后。");
                    var service = ServiceBuilder.ReBuildService(t, true);
                    var runOperations = service.Operations;
                    //while (Start)
                    //{                        
                    var operations = runOperations.GroupBy(x => x.OperateTarget).OrderBy(x => x.Key);
                    this.LogTxt($"初始化任务：“{t.ServiceDescription}”完成，有{operations.Count()}个操作进行。策略：{service.ServicePolicy}");
                    try
                    {
                        foreach (var item in operations)
                        {
                            do
                            {
                                foreach (var operation in item.SelectMany(x => x.Operations))
                                {
                                    operation.HandleOperationMethod(service, (m, p) =>
                                     {
                                         operation.ExeuteOperationMethod(m, p);
                                     });

                                    if (!Start) break;
                                }
                            } while (service.ServicePolicy == ServicePolicyEnum.Loop && item.Key == "1" && Start);
                        }
                        if (service.AnotherOperations != null && service.AnotherOperations.Count > 0)
                        {
                            //var another = ServiceBuilder.ReBuildService(this.MapleConfig.ServiceData.First(x => x.Guid == serviceId), true);
                            //runOperations = service.AnotherOperations.Distinct().ToList();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    //}
                }));
            });
        }
    }
}
