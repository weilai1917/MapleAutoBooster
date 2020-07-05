using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Abstract
{
    public interface IOperation
    {
        string OperationString { get; set; }
        string DoWork(Func<string> work);
    }
}
