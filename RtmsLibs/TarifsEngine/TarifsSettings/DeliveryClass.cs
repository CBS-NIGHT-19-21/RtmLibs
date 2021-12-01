using Newtonsoft.Json;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Контрольные стрки доставки
    /// </summary>
    public class DeliveryClass
    {
        /// <summary>
        /// Минимальное нормативное количество дней доставки отправления. Обязательно
        /// </summary>
        [JsonProperty("min")]
        public int MinDay { get; set; }
        /// <summary>
        /// Максимальное нормативное количество дней доставки отправления. Обязательно
        /// </summary>
        [JsonProperty("max")]
        public int MaxDay { get; set; }
        /// <summary>
        /// Крайний срок доставки отправления в формате ISO 8601. Опционально
        /// </summary>
        [JsonProperty("deadline")]
        public string DeadLine { get; set; }
    }
}