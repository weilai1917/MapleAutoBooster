using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Operations
{
    public interface IOperation
    {
        string OperationKey { get; }
        /// <summary>
        /// 创建新示例
        /// </summary>
        /// <returns></returns>
        IOperation CreateInstance();
        /// <summary>
        /// 执行具体工作
        /// </summary>
        /// <param name="param">是一个弱类型参数，个数不确定，由json指定</param>
        object Do(string param);
    }
}
