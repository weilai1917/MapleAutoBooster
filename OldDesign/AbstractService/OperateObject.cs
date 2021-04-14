using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Abstract
{
    [Serializable]
    public class OperateObject
    {
        /// <summary>
        /// Id
        /// </summary>
        public string OperateId { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string OperateKey { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public string OperateTarget { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperateName { get; set; }
        /// <summary>
        /// 操作描述
        /// </summary>
        public string OperateDescription { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public ICollection<IOperation> Operations { get; set; }
    }
}
