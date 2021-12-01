using Newtonsoft.Json;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Список услуг для стран
    /// </summary>
    public class CountryServises
    {
        /// <summary>
        /// Значение true указывает на наличие услуги ОЦ при отправке в страну
        /// </summary>
        [JsonProperty("sumoc")]
        public bool IsSumoc { get; set; }
        /// <summary>
        /// Значение true указывает на наличие услуги НП при отправке в страну
        /// </summary>
        [JsonProperty("sumnp")]
        public bool IsSumnp { get; set; }
        /// <summary>
        /// Список кодов услуг, которые должны быть отменены при использовании
        /// текущей услуги при отправке в страну
        /// </summary>
        [JsonProperty("serviceoff")]
        public int[] ServisesOff { get; set; }
    }
}