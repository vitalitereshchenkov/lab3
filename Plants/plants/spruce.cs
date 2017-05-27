using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.plants
{
    [Serializable]
    public class spruce : tree
    {
        public spruce() { }

        public string color { get; set; }
    }
}
