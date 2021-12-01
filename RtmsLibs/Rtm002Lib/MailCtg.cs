using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Lib
{
    /// <summary>
    /// Категория почтовых отправлений
    /// </summary>
    public enum MailCtg
    {
        Простое = 0,
        Заказное = 1,
        С_объявленной_ценностью = 2,
        Обыкновенное = 3,
        С_объявленной_ценностью_и_наложенным_платежом = 4,
        Не_определена = 5,
        С_объявленной_ценностью_и_обязательным_платежом = 6,
        С_обязательным_платежом = 7
    }
}
