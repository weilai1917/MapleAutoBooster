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
        public List<CustomBindValue> HotKeys
        {
            get { return this["HotKeys"] as List<CustomBindValue>; }
            set { this["HotKeys"] = value; }
        }

        [UserScopedSetting]
        public List<CustomBindValue> GroupData
        {
            get { return this["GroupData"] as List<CustomBindValue>; }
            set { this["GroupData"] = value; }
        }

        [UserScopedSetting]
        public string HotKeyServiceBoot
        {
            get { return Convert.ToString(this["HotKeyServiceBoot"]); }
            set { this["HotKeyServiceBoot"] = value; }
        }

        [UserScopedSetting]
        public string HotKeyServiceStop
        {
            get { return Convert.ToString(this["HotKeyServiceStop"]); }
            set { this["HotKeyServiceStop"] = value; }
        }

        [UserScopedSetting]
        public string HotKeyKeyRecord
        {
            get { return Convert.ToString(this["HotKeyKeyRecord"]); }
            set { this["HotKeyKeyRecord"] = value; }
        }

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
        public string ServiceGroup { get; set; } = string.Empty;
        public ServicePolicyEnum ServicePolicy { get; set; }
        public bool IsRun { get; set; }
        public string Operations { get; set; }

        //由于自带的xml序列化不支持集合再集合，利用string反序列化吧
        //public ICollection<OperateObject> Operatetions { get; set; }
    }
}
