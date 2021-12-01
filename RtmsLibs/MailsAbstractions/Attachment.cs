using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.MailsAbstractions
{
    /// <summary>
    /// Дополнительные данные для отправления
    /// </summary>
    public class Attachment
    {

        /// <summary>
        /// Код типа SMS-уведомления для получателя при заказе услуги «SMS-уведомление».
        /// </summary>
        public string SMSNoticeR { get; set; }
        /// <summary>
        /// Данные таможенной декларации в формате XML (кодировка UTF-8, структура согласно РТМ 0030.12-16 [4]) , закодированные в строку Base64.
        /// </summary>
        public string MPODeclaration { get; set; }
        /// <summary>
        /// ШПИ ОС
        /// </summary>
        public string ApoNum { get; set; }
    }
}
