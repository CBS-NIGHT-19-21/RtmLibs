using Newtonsoft.Json;

namespace RtmLib.CheckSpi
{
    /// <summary>
    /// Ответ по отслеживанию ШПИ
    /// </summary>
    public class ResponseCheck
    {
        [JsonProperty("formF22Params")]
        public MainDelInfo MainInfo { get; set; }
        [JsonProperty("trackingItem")]
        public TrackingItemsClass TrakingItems { get; set; }
    }
}