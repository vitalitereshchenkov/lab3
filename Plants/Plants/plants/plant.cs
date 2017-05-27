using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Plants.plants
{
    [Serializable(), XmlInclude(typeof(tree)), XmlInclude(typeof(grass)), XmlInclude(typeof(cannabis)), XmlInclude(typeof(coriander)), XmlInclude(typeof(spruce)), XmlInclude(typeof(birch))]
    public class plant
    {
        public plant() { }

        public int height { get; set; }
        public string origin { get; set; }
        public string name { get; set; }
    }
}
