using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm002Lib
{
    /// <summary>
    /// Направление доставки отправления
    /// </summary>
    public enum DirectCtg
    {
        /// <summary>
        /// Согласно РТМ002
        /// </summary>
        Внутренняя = 0,
        /// <summary>
        /// Согласно РТМ002
        /// </summary>
        Международная = 1,
        /// <summary>
        /// Согласно тарификтора
        /// </summary>
        Входящее_Международное = 2,
        /// <summary>
        /// Согласно тарификтора
        /// </summary>
        Тразнитное_Международное = 3,
        /// <summary>
        /// Согласно тарификтора
        /// </summary>
        Внутреннее_Возвратное = 4
    }
}
