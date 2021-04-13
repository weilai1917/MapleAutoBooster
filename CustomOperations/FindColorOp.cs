using MapleAutoBooster.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.CustomOperations
{
    public class FindColorOp : AbstractOperation
    {
        public override string OperationKey { get { return ""; } }

        public override IOperation CreateInstance()
        {
            return new FindColorOp();
        }

        public override object Do(string param)
        {
            throw new NotImplementedException();
        }
    }
}
