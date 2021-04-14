using MapleAutoBooster.Operations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Services
{
    public abstract class AbstractService : AbstractDynamicService
    {
        /// <summary>
        /// 是否为被订阅的服务
        /// </summary>
        public abstract bool IsSubject { get; }

    }
}
