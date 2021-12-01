using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.MailsAbstractions
{
    /// <summary>
    /// Доп информация по объявленной ценности и наложенному платежу
    /// </summary>
    public class AddictionalPayment
    {
        /// <summary>
        /// Сумма объявленной ценности
        /// </summary>
        public int SumOp { get; set; }
        /// <summary>
        /// Сумма наложенного платежа
        /// </summary>
        public int SumNp { get; set; }
        /// <summary>
        /// Код единицы измерения суммы наложенного платежа. Alphabetic Code согласно ISO 4217
        /// </summary>
        public string PaymentCurrency { get; set; }
    }
    
}
