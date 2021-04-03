using MapleAutoBooster.CustomOperations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Operations
{
    public class OperationTypeContainer
    {
        public static ConcurrentDictionary<object, object> instance = new ConcurrentDictionary<object, object>();

        public static List<Type> ScanOperationTypes()
        {
            return new List<Type>()
            {
                typeof(FindWindowOp),
                typeof(PressActionKeyOp),
                typeof(PressDirectKeyOp)
            };
        }

        public static IOperation RegisteOperationType(IOperation op)
        {
            return (IOperation)instance.GetOrAdd(op.GetType(), op.CreateInstance());
        }


    }
}
