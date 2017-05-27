using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.plants
{
    [Serializable]
    public class tree : plant
    {
        public tree() { }

        public string leavesType {get; set;}
    }
}
