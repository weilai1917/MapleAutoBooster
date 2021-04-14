using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleAutoBooster.Operations
{
    /// <summary>
    /// 操作的定义是执行某一项具体任务
    /// 
    /// </summary>
    public abstract class AbstractOperation : IOperation
    {
        public static ThreadLocal<Dictionary<string, object>> ThreadOptions;
        public abstract string OperationKey { get; }

        protected string operationId;
        protected string operationName;
        protected string operationDescription;
        /// <summary>
        /// opId
        /// </summary>
        protected string OperationId { get => operationId; set => operationId = value; }
        /// <summary>
        /// op名称
        /// </summary>
        public string OperationName { get => operationName; set => operationName = value; }
        /// <summary>
        /// op描述
        /// </summary>
        public string OperationDescription { get => operationDescription; set => operationDescription = value; }

        public abstract IOperation CreateInstance();

        public abstract object Do(string param);
    }
}
