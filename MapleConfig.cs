using MapleAutoBooster.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster
{
    public sealed class MapleConfig : ApplicationSettingsBase
    {
        [UserScopedSetting]
        public List<ServiceConfig> ServiceData
        {
            get { return this["ServiceData"] as List<ServiceConfig>; }
            set { this["ServiceData"] = value; }
        }
    }


    [Serializable]
    public class ServiceConfig
    {
        public string Guid { get; set; }
        public string ServiceTypeId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public ServicePolicyEnum ServicePolicy { get; set; }
        public bool IsRun { get; set; }
        public string Operations { get; set; }

        //由于自带的xml序列化不支持集合再集合，利用string反序列化吧
        //public ICollection<OperateObject> Operatetions { get; set; }
    }
}
