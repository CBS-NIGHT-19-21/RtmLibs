using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.PostAbstractions
{
    /// <summary>
    /// Интерфейс подразумевает что абстракция имеет возможность рассчитывать тарифы
    /// </summary>
    public interface ITarifs
    {
        /// <summary>
        /// Получить тарфи для отпралвения в копейках
        /// </summary>
        /// <returns></returns>
        TarifsClass GetTarifs();
        /// <summary>
        /// Проверить тариф для отпралвния. 
        /// </summary>
        /// <returns></returns>
        bool CheckTarifs(Postage postage);

    }
}
