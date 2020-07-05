using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Abstract
{
    [Serializable]
    public class Operation : IOperation
    {
        private string _OperationString;
        public string OperationString { get => _OperationString; set => _OperationString = value; }

        public Operation(string opString)
        {
            this._OperationString = opString;
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
