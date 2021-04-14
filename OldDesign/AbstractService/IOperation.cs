using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Abstract
{
    public interface IOperation
    {
        string OperationString { get; set; }
        string DoWork(Func<string> work);

        void HandleOperationMethod(AbstractBoosterService service, Action<MethodInfo, string[]> method);

        bool ValidateOperationMethod(MethodInfo method, string[] param);

        void ExeuteOperationMethod(AbstractBoosterService service, MethodInfo method, string[] param);

        string GetOperationMethodText(MethodInfo method, string[] param);
    }
}
