using MapleAutoBooster.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Services
{
    public abstract class AbstractService
    {
        private int serviceId;
        private string serviceName;
        private int serviceType;
        private string serviceRemark;
        private ICollection<AbstractOperation> operations;

        /// <summary>
        /// 服务ID
        /// </summary>
        public int ServiceId { get => serviceId; set => serviceId = value; }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get => serviceName; set => serviceName = value; }
        /// <summary>
        /// 服务类型
        /// </summary>
        public int ServiceType { get => serviceType; set => serviceType = value; }
        /// <summary>
        /// 服务描述
        /// </summary>
        public string ServiceRemark { get => serviceRemark; set => serviceRemark = value; }
        /// <summary>
        /// 服务操作集合
        /// </summary>
        public ICollection<AbstractOperation> Operations { get => operations; set => operations = value; }

        /// <summary>
        /// 通过后台获得的简易服务对象
        /// </summary>
        /// <param name="id">服务ID</param>
        /// <param name="name">服务名称</param>
        /// <param name="ops">服务操作集合</param>
        public AbstractService(int id, string name, ICollection<AbstractOperation> ops)
        {
            this.serviceId = id;
            this.serviceName = name;
            this.operations = ops;
        }
        
       
    }
}
