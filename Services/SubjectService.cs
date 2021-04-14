using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Services
{
    /// <summary>
    /// subject service 有可以主动订阅其他服务的特性
    /// </summary>
    public class SubjectService : AbstractService
    {
        public override bool IsSubject { get { return true; } }

        public IEnumerable<AbstractService> SubjectServices;

        public SubjectService(List<AbstractService> services)
        {
            this.SubjectServices = services.Where(x => !x.IsSubject);
        }

        public override void DoService()
        {
            while (this.IsStart)
            {
                this.RunOperations();

                if (SubjectServices != null && SubjectServices.Count() > 0)
                {
                    foreach (AbstractService service in SubjectServices)
                    {
                        service.DoService();
                    }
                }
            }
        }
    }
}
