using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Services
{
    /// <summary>
    /// service 可以被subject 服务订阅
    /// </summary
    public class Service : AbstractService
    {
        public override bool IsSubject { get { return false; } }

        public override void DoService()
        {
            this.RunOperations();
        }
    }
}
