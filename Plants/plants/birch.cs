using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.plants
{
    [Serializable]
    public class birch : tree
    {
        public birch() { }

        public int age { get; set; }
    }
}
