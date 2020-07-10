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
                Parallel.ForEach(this.MapleConfig.ServiceData.Where(x => x.IsRun), new Action<ServiceConfig>(t =>
                {
                    var service = ServiceBuilder.ReBuildService(t, true);
                    service.RunAllOperations("1", ref Start);//run 将会在这阻塞

                    //如果出来了，就继续走another service
                    if (service.AnotherOperations != null && service.AnotherOperations.Count > 0)
                    {
                        this.RecursionService(service.AnotherOperations.Distinct().ToList());
                    }
                }));
            });
        }

        private void RecursionService(List<string> anotherOperations)
        {
            if (!Start)
                return;

            foreach (var serviceId in anotherOperations)
            {
                var another = ServiceBuilder.ReBuildService(this.MapleConfig.ServiceData.First(x => x.Guid == serviceId), true);
                another.RunAllOperations("1", ref Start);
                if (another.AnotherOperations != null)
                {
                    this.RecursionService(another.AnotherOperations.Distinct().ToList());
                }
            }
        }
    }
}
