using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsEnums
{
    /// <summary>
    /// Указание на формат данных в ответе
    /// </summary>
    public enum TarifsQuerySettingsEnum
    {
        json = 0,
        jsontext = 1,
        html = 2,
        htmlfull = 3,
        text = 4
    }
}
