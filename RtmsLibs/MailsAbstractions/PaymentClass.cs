using RtmLib.TarifsEngine.TarifsSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.MailsAbstractions
{
    /// <summary>
    /// Класс для опередления оплаты
    /// </summary>
    public class PaymentClass
    {
        /// <summary>
        /// Сбор за вес
        /// </summary>
        public TarifJsonClass MassRate { get; set; }
        /// <summary>
        /// Сбор за ОЦ
        /// </summary>
        public TarifJsonClass CurrencyRate { get; set; }
        /// <summary>
        /// Сбор за авиа перевозку
        /// </summary>
        public TarifJsonClass AirRate { get; set; }
        /// <summary>
        /// Сбор за доп услуги
        /// </summary>
        public TarifJsonClass ServicesRate { get; set; }
        /// <summary>
        /// Итоговая сумма платы без НДС в копейках
        /// </summary>
        public int Pay { get; set; }
        /// <summary>
        /// Сумма НДС в копейках (в валюте расчета)
        /// </summary>
        public int Nds { get; set; }
        /// <summary>
        /// Итоговая сумма платы с НДС в копейках
        /// </summary>
        public int Paynds { get; set; }
        /// <summary>
        /// Ставка НДС в процентах
        /// </summary>
        public int Ndsrate { get; set; }
        /// <summary>
        /// Итоговая сумма при оплате почтовыми марками в копейках (всегда кратна рублю)
        /// </summary>
        public int Paymark { get; set; }
    }
}
