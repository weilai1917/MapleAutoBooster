using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapleAutoBooster.Abstract
{
    public class ServiceBuilder
    {
        public static AbstractBoosterService ReBuildService(ServiceConfig config, bool Runtime)
        {
            Type serviceType = Type.GetType(config.ServiceTypeId);
            if (serviceType == null || !typeof(AbstractBoosterService).IsAssignableFrom(serviceType))
                return null;
            AbstractBoosterService service = (AbstractBoosterService)Activator.CreateInstance(serviceType);
            service.Id = config.Guid;
            service.ServiceTypeId = config.ServiceTypeId;
            service.ServiceName = config.ServiceName;
            service.ServiceGroup = config.ServiceGroup;
            service.ServicePolicy = config.ServicePolicy;
            service.ServiceDescription = config.ServiceDescription;
            service.Operations = new List<OperateObject>();

            //解析所有的操作
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
                        IOperation operation = new Operation(opItem["OperationString"].ToString());
                        operation.HandleOperationMethod(service, (m, p) =>
                         {
                             if (operation.ValidateOperationMethod(m, p))
                                 opObject.Operations.Add(operation);
                         });
                    }
                    service.Operations.Add(opObject);
                }
            }
            return service;
        }

        public static ServiceConfig BuildKeyRecord(string groupKey, List<RecordKeyData> RecordList)
        {
            ServiceConfig config = new ServiceConfig();
            config.Guid = Guid.NewGuid().ToString();
            config.ServiceTypeId = "MapleAutoBooster.Service.AutoKeyService";
            config.ServiceName = "自动按键";
            config.ServicePolicy = Abstract.ServicePolicyEnum.Once;
            config.ServiceGroup = groupKey;// CurrGroupKey;
            config.ServiceDescription = $"总时长：{RecordList.Sum(x => x.Wait) / 1000}s，动作数：{RecordList.Count}";
            var opObject1 = new OperateObject();
            opObject1.OperateId = Guid.NewGuid().ToString();
            opObject1.OperateTarget = "1";
            opObject1.Operations = new List<IOperation>();
            foreach (var item in RecordList)
            {
                opObject1.Operations.Add(new Operation($"PressKey[{item.Key},{item.Action},{item.Wait}]"));
            }
            var opObject0 = new OperateObject();
            opObject0.OperateId = Guid.NewGuid().ToString();
            opObject0.OperateTarget = "0";
            opObject0.Operations = new List<IOperation>();
            opObject0.Operations.Add(new Operation($"LockMapleWindow[]"));
            config.Operations = JsonConvert.SerializeObject(new List<OperateObject>() { opObject0, opObject1 });
            return config;
        }
    }
}
