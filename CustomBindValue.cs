using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    public class CustomBindValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class RecordKeyData
    {
        public Keys Key { get; set; }
        public int Action { get; set; }
        public long Wait { get; set; }

        public RecordKeyData(Keys key, int action, long wait)
        {
            this.Key = key;
            this.Action = action;
            this.Wait = wait;
        }

    }
}
