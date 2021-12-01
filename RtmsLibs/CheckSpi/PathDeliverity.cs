using Newtonsoft.Json;
using System;

namespace RtmLib.CheckSpi
{
    /// <summary>
    /// Информация о пути отпрлвений
    /// </summary>
    public class PathDeliverity
    {
        [JsonProperty("date")]
        public DateTime? DatePath { get; set; }
        [JsonProperty("humanStatus")]
        public string StatusString { get; set; }
        [JsonProperty("humanOperationStatus")]
        public string StatusOperationString { get; set; }
        [JsonProperty("index")]
        public string Index { get; set; }
        [JsonProperty("operationType")]
        public int OperationType { get; set; }
        [JsonProperty("operationAttr")]
        public int OperationAttr { get; set; }
        [JsonProperty("countryId")]
        public int CountryId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("weight")]
        public int? Weight { get; set; }
        [JsonProperty("cityName")]
        public string CityName { get; set; }
        [JsonProperty("countryName")]
        public string CountryName { get; set; }
        [JsonProperty("countryNameGenitiveCase")]
        public string CountryNameGenitiveCase { get; set; }
        [JsonProperty("countryCustomName")]
        public string CountryCustomName { get; set; }
        [JsonProperty("isInInternationalTracking")]
        public bool? IsInInternationalTracking { get; set; }
    }
}