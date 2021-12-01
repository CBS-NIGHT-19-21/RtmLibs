using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.CheckSpi.CheckSpiEntr.JsonAnsvers
{
    public class ChekcSpiResponse
    {
        [JsonProperty("hasHidden")]
        public bool IsHasHidden { get; set;}
        [JsonProperty("hasHiddenPostalOrderHistory")]
        public bool IsHasHiddenPostalOrderHistory { get; set; }
        [JsonProperty("hasHiddenNotificationHistory")]
        public bool IsHasHiddenNotificationHistory { get; set; }
        [JsonProperty("summary")]
        public SummaryResponce Summary { get; set; }
        [JsonProperty("postalOrderHistory")]
        public object[] PostalOrderHistory { get; set; }
        [JsonProperty("notifications")]
        public object[] Notifications { get; set; }
        [JsonProperty("history")]
        public HystortClass[] HysroryDel { get; set; }


    }
}
