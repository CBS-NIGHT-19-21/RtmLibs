using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.MailsAbstractions
{
    /// <summary>
    /// Класс для дат доставки, дат отправки и контрольный строков
    /// </summary>
    public class DatesDelivery
    {
        /// <summary>
        /// Дата отправки отправления
        /// </summary>
        public DateTime DeliberySend { get; set; }
        /// <summary>
        /// Даты полученя отправления
        /// </summary>
        public DateTime DateDoneDelivery { get; set; }
        /// <summary>
        /// Максимальное количетво дней доставки по контрльным срокам
        /// </summary>
        public int MaxDayDeliver { get; set; }
        /// <summary>
        /// Минимальное количево дней доставки по контрльным срокам
        /// </summary>
        public int MinDayDeliver { get; set; }
    }
}
