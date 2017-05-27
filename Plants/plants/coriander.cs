using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.plants
{
    [Serializable]
    public class coriander : grass
    {
        public coriander() { }

        public string recipe { get; set; }
    }
}
