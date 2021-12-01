using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Classes.BatchClasses
{
    /// <summary>
    /// Данные по контракту с отрпавителем
    /// </summary>
    public class SenderContract
    {
        /// <summary>
        /// Номер контракта
        /// </summary>
        public string NameContract { get; set; }
        /// <summary>
        /// Дата начало действия контракта
        /// </summary>
        public DateTime DateStartContract { get; set; }
        /// <summary>
        /// Дата конца действия контракта (поддреживате null)
        /// </summary>
        public DateTime? DateEndContract { get; set; }
        /// <summary>
        /// Закончен ли контракт
        /// </summary>
        public bool IsClosed { get; set; }

    }
}
