using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Lib
{
    /// <summary>
    /// Разряд почтового отпралвения
    /// </summary>
    public enum MailRank
    {
        Без_разряда = 0,
        Правительственное = 1,
        Воинское = 2,
        Служебное = 3,
        Судебное = 4,
        Президентское = 5,
        Кредитное= 6,
        Межоператорское = 7,
        Административное = 8
    }
}
