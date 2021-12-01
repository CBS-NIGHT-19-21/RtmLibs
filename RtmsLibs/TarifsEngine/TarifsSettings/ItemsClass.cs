using Newtonsoft.Json;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Части рассчета тарифа
    /// </summary>
    public class ItemsClass
    {
        /// <summary>
        /// Код шага расчета. Не является постоянной величиной, изменяется со временем у одного и того же объекта
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Наименование шага расчета
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Индекс места отправления. Опционально
        /// </summary>
        [JsonProperty("from")]
        public int From { get; set; }
        /// <summary>
        /// Индекс места назначения. Опционально
        /// </summary>
        [JsonProperty("to")]
        public int To { get; set; }
        /// <summary>
        /// Список кодов дополнительных услуг, вариантов расчета и указателей, которые используются на шаге расчета.
        /// </summary>
        [JsonProperty("serviceon")]
        public int[] ServiseOn { get; set; }
        /// <summary>
        /// Коды услуг, применение которых отменяет шаг расчета.
        /// </summary>
        [JsonProperty("serviceoff")]
        public int[] ServiseOff { get; set; }
        /// <summary>
        /// Массив дополнительной информации о шаге расчета
        /// </summary>
        [JsonProperty("steps")]
        public StepsClass[] Steps { get; set; }
        /// <summary>
        /// Тариф на шаге расчета, если шаг применяется при расчете тарифа
        /// </summary>
        [JsonProperty("tariff")]
        public TarifJsonClass Tariff { get; set; }
        /// <summary>
        /// Контрольные сроки доставки Обязательно, если шаг применяется при расчете контрольных сроков
        /// </summary>
        [JsonProperty("delivery")]
        public DeliveryClass Delivery { get; set; }

    }
}