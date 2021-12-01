using RtmLib.Addresses;
using RtmLib.Attributes;
using RtmLib.MailsAbstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Classes
{
    /// <summary>
    /// Отпралвение для формирования списка
    /// </summary>
    public abstract class RtmEntry
    {
        /// <summary>
        /// Показывает отображение расчитаны ли тарифы
        /// </summary>
        public bool IsTarifsCalculate { get; set; }
        /// <summary>
        /// Отправление 
        /// </summary>
        public DelivertytyAbstractionss Delivertyty { get; set; }
        /// <summary>
        /// Получить строку для спика РТМ
        /// </summary>
        /// <returns></returns>
        public abstract string GetRtmString();
        /// <summary>
        /// Ошибки в отправлении
        /// </summary>
        public List<ErrorsClassRtm> ErrorsEntity { get; set; } = new List<ErrorsClassRtm>();
    }
}
