using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Lib
{
    /// <summary>
    /// Тип адреса
    /// </summary>
    public enum AddressType 
    {
        Стандратный_Адрес = 0,
        А_я = 1,
        До_Восстребования = 2,
        Войсковая_часть = 3,
        Гостиница = 4,
        Войсковая_часть_ЮЯ = 5,
        Полевая_почта = 6
    }
}
