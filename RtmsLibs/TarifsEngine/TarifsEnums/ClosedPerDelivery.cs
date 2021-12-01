using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsEnums
{
    /// <summary>
    /// Признак возможности или невозможности расчета во временно закрытый для доставки период
    /// </summary>
    public enum ClosedPerDeliveryEnum
    {
        No = 1,
        Yes = 0
    }
}
