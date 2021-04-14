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
        public static ConcurrentDictionary<string, object> _OperationName = new ConcurrentDictionary<string, object>();
        static ConcurrentDictionary<object, object> instance = new ConcurrentDictionary<object, object>();

        public static List<Type> ScanOperationTypes()
        {
            return new List<Type>()
            {
                typeof(FindWindowOp),
                typeof(PressActionKeyOp),
                typeof(PressDirectKeyOp)
            };
        }

        public static IOperation RegisterOperationType(Type op)
        {
            return (IOperation)instance.GetOrAdd(op.GetType(), ((IOperation)op).CreateInstance());
        }

        public static IOperation RegisterOperationType(IOperation op)
        {
            _OperationName.GetOrAdd(op.OperationKey, op.GetType());
            return (IOperation)instance.GetOrAdd(op.GetType(), op.CreateInstance());
        }


    }
}
