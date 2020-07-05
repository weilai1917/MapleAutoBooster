using MapleAutoBooster.AbstractOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster.Abstract
{
    public interface IService
    {
        string ServiceTypeId { get; set; }
        string ServiceName { get; set; }
        string ServiceDescription { get; set; }

        ServicePolicyEnum ServicePolicy { get; set; }

    }
}
