using Newtonsoft.Json;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Значчение тарифа
    /// </summary>
    public class TarifJsonClass
    {
        /// <summary>
        /// Значение тарифа без НДС в копейках. Обязательно
        /// </summary>
        [JsonProperty("val")]
        public int ValTarif { get; set; }
        /// <summary>
        /// Значение тарифа с НДС в копейках. Обязательно
        /// </summary>
        [JsonProperty("ValNds")]
        public int ValNds { get; set; }
        /// <summary>
        /// Значение тарифа при оплате почтовыми марками. Опционально
        /// </summary>
        [JsonProperty("ValMark")]
        public int ValMark { get; set; }
    }
}