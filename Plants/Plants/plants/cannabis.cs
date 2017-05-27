using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.plants
{
    [Serializable]
    public class cannabis : grass
    {
        public cannabis() { }
        
        public string kind { get; set; }
    }
}
