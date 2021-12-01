using Newtonsoft.Json;
using RtmLib.TarifsEngine.TarifsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Информация по стране исходя из Тарификатора
    /// </summary>
    public class CountryClass
    {
        /// <summary>
        /// Код страны согласно РТМ-2. Обязательно
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Наименование страны. Обязательно
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Группа ограничений, используемая для расчета
        /// k – письменная корреспонденция;
        /// p – посылки;
        /// e – ЕМС
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }
        /// <summary>
        /// Признак разрешения на отправления с объявленной ценностью
        /// </summary>
        [JsonProperty("oc")]
        public CurrencySend CurrencySendProp { get; set; }
        /// <summary>
        /// Признак разрешения на отправления с наложенным платежом
        /// </summary>
        [JsonProperty("np")]
        public PaymentOndelivery PaymentOndeliveryProp { get; set; }
        /// <summary>
        /// Список не оказываемых дополнительных услуг в стране
        /// </summary>
        [JsonProperty("serviceoff")]
        public int[] ServicesOffCountry { get; set; }

    }
}
