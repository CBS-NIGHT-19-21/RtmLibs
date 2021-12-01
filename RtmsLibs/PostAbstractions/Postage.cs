using RtmLib.Addresses;
using RtmLib.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.PostAbstractions
{
    /// <summary>
    /// Общее значение об отправении
    /// </summary>
    public abstract class Postage
    {
        public int Weight { get; set; }
        public BarcodeClass Barcode { get; set; }
        public AddressRtm Address { get; set; }



    }
}
