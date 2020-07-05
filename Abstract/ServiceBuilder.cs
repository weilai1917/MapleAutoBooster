using MapleAutoBooster.AbstractOperate;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Abstract
{
    public class ServiceBuilder
    {
        public static AbstractService ReBuildService(ServiceConfig config, bool Runtime)
        {
            Type serviceType = Type.GetType($"MapleAutoBooster.Service.{config.ServiceTypeId}");
            AbstractService service = (AbstractService)Activator.CreateInstance(serviceType);
            service.Id = config.Guid;
            service.ServiceTypeId = config.ServiceTypeId;
            service.ServiceName = config.ServiceName;
            service.ServicePolicy = config.ServicePolicy;
            service.ServiceDescription = config.ServiceDescription;
            service.Operations = new List<OperateObject>();

            var operations = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(config.Operations);
            if (operations != null && operations.Count > 0)
            {
                foreach (var item in operations)
                {
                    var opObject = new OperateObject()
                    {
                        OperateId = item["OperateId"].ToString(),
                        OperateTarget = item["OperateTarget"].ToString(),
                        OperateDescription = item["OperateDescription"].ToString(),
                        Operations = new List<IOperation>(),
                    };
                    foreach (var opItem in item["Operations"] as JArray)
                    {
                        var operation = new Operation(opItem["OperationString"].ToString());
                        if (service.AnalyseOperation(service, operation))
                        {
                            opObject.Operations.Add(operation);
                        }
                    }
                    service.Operations.Add(opObject);
                }
            }
            service.Runtime = Runtime;
            return service;
        }
    }
}
