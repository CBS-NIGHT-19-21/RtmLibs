using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsEnums
{
    /// <summary>
    /// Предпочтительный вариант доставки
    /// </summary>
    public enum TarifsSenderHelper
    {
        PreferLand = 0,
        PreferAvia = 1,
        OnlyAvia = 2
    }
}
