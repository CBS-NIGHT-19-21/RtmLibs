using Newtonsoft.Json;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Шаги расчета
    /// </summary>
    public class StepsClass
    {
        /// <summary>
        /// Информационное сообщение
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}