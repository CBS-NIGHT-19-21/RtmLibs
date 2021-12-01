using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Lib
{
    /// <summary>
    /// Тип доставки почтовых отправлнеий
    /// </summary>
    public enum TransTypes
    {
        Наземный = 0,
        Авиа = 1,
        Комбинированный = 2,
        Системой_ускоренной_почты = 3,
        Электронный = 4,
        Стандарт = 5
    }
}
