using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Abstract
{
    [Serializable]
    public class Operation : AbstractOperation, IOperation
    {
        public Operation(string opString)
        {
            this.OperationString = opString;
        }

        public string DoWork(Func<string> work)
        {
            if (work != null)
            {
                return work.Invoke();
            }
            return string.Empty;
            //if (callback != null)
            //{
            //    callback.Invoke();
            //}
        }
    }
}
