using MapleAutoBooster.Operations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleAutoBooster.Services
{
    public abstract class AbstractDynamicService
    {
        private int serviceId;
        private string serviceName;
        private int serviceType;
        private string serviceRemark;
        private ICollection<object> operations;
        private bool isStart = false;
        private bool isPause = false;

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
        public ICollection<object> Operations { get => operations; set => operations = value; }
        public bool IsStart { get => isStart; }
        public bool IsPause { get => isPause; }

        public AbstractDynamicService()
        {
            this.serviceId = 0;
            this.serviceName = string.Empty;
        }

        /// <summary>
        /// 通过后台获得的简易服务对象
        /// </summary>
        /// <param name="id">服务ID</param>
        /// <param name="name">服务名称</param>
        /// <param name="ops">服务操作集合</param>
        public AbstractDynamicService(int id, string name)
        {
            this.serviceId = id;
            this.serviceName = name;
        }

        public AbstractDynamicService(int id, string name, JArray ops)
            : this(id, name)
        {
            if (ops == null || ops.Count <= 0)
            {
                throw new Exception("does not register ops");
            }
            this.operations = new List<object>();

            var index = 0;
            foreach (var o in ops)
            {
                string opKey = Convert.ToString(o["k"]);
                string opParam = Convert.ToString(o["p"]);
                object opType;
                if (OperationTypeContainer._OperationName.TryGetValue(opKey, out opType))
                {
                    this.operations.Add(new OperationNode(index, OperationTypeContainer.RegisterOperationType((Type)opType), opParam));
                }
            }
        }

        class OperationNode
        {
            public int order;
            public IOperation opertation;
            public string opParam;
            public OperationNode(int o, IOperation p, string param)
            {
                this.order = o;
                this.opertation = p;
                this.opParam = param;
            }
        }

        /// <summary>
        /// 按顺序，执行所有的操作
        /// </summary>
        public void RunOperations()
        {
            foreach (OperationNode operations in this.Operations)
            {
                if (operations == null)
                    continue;

                while (this.isPause)
                {
                    Thread.Sleep(100);
                }

                operations.opertation.Do(operations.opParam);
            }
        }

        public abstract void DoService();


        public void StopService()
        {
            this.isStart = false;
        }

        public void StartService()
        {
            this.isStart = true;
        }

        public void PauseService()
        {
            this.isPause = true;
        }

        public void ResumeService()
        {
            this.isPause = false;
        }
    }
}
