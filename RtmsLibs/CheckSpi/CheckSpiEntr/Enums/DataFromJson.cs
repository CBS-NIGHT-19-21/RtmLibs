using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.CheckSpi.CheckSpiEntr.Enums
{
    public class DataFromJson
    {
        public string RootName { get; set; }
        public int RootIndex { get; set; }
        public RootChild[] RootChilds { get; set; }
    }
}
