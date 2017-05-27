using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.plants
{
    [Serializable]
    public class grass : plant
    {
        public string type { get; set; }
        public int weight { get; set; }
        public int price { get; set; }

        public grass() { }
    }
}
