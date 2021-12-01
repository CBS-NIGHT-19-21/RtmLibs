using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Lib
{
    /// <summary>
    /// Категории отправителей
    /// </summary>
    public enum SendCtg
    {
        Население = 0,
        Бюджетная_организация = 1,
        Хозрасчетная_организация = 2,
        Международный_оператор = 3,
        Корпоративный_клиент = 4,
        Почтовый_оператор = 5
    }
}
