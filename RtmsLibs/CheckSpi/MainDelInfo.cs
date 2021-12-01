using Newtonsoft.Json;

namespace RtmLib.CheckSpi
{
    /// <summary>
    /// Основная информация по форме 22
    /// </summary>
    public class MainDelInfo
    {
        [JsonProperty("Letter")]
        public bool IsLetter { get; set; }
        [JsonProperty("MailTypeText")]
        public string MailTypeString { get; set; }
        [JsonProperty("MailRankText")]
        public string MailRankString { get; set; }
        [JsonProperty("senderAddress")]
        public string SenderAddress { get; set; }
        [JsonProperty("RecipientIndex")]
        public string RecipientIndex { get; set; }
        [JsonProperty("WeightGr")]
        public int Wight { get; set; }
        [JsonProperty("SendingType")]
        public string TypeString { get; set; }
        [JsonProperty("Ordered")]
        public bool IsOrdered { get; set; }
        [JsonProperty("MailCtgText")]
        public string MailCtgString { get; set; }
        [JsonProperty("state")]
        public object StateObj { get; set; }
        [JsonProperty("PostId")]
        public string Barcode { get; set; }
    }
}