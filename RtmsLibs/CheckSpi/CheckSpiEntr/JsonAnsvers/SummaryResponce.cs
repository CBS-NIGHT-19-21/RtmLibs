using Newtonsoft.Json;
using RtmLib.Rtm002Lib;
using System.Collections.Generic;

namespace RtmLib.CheckSpi.CheckSpiEntr.JsonAnsvers
{
    public class SummaryResponce
    {
        [JsonProperty("linkedBarcodes")]
        public string[] LinkedBarcodes { get; set; }
        [JsonProperty("postMarkList")]
        public string[] PostMarks { get; set; }
        [JsonProperty("opmIds")]
        public object[] OpmIds { get; set; }
        [JsonProperty("smsInformation")]
        public object SmsInformation { get; set; }
        [JsonProperty("mailType")]
        public string MailType { get; set; }
        [JsonProperty("mailCategory")]
        public string MailCategory { get; set; }
        [JsonProperty("mailRank")]
        public string MailRank { get; set; }
        [JsonProperty("transType")]
        public string TransType { get; set; }
        [JsonProperty("sndr")]
        public string Sndr { get; set; }
        [JsonProperty("senderCategory")]
        public string SenderCategory { get; set; }
        [JsonProperty("rcpn")]
        public string Rcpn { get; set; }
        [JsonProperty("customsInfo")]
        public object CustomsInfo { get; set; }
        [JsonProperty("mpoDeclaration")]
        public object MpoDeclaration { get; set; }
        [JsonProperty("multiplaceBarcode")]
        public object MultiplaceBarcode { get; set; }
        [JsonProperty("eorderNumber")]
        public object EorderNumber { get; set; }
        [JsonProperty("opmServiceUnavailable")]
        public bool OpmServiceUnavailable { get; set; }
        [JsonProperty("hyperlocalDelivery")]
        public object HyperlocalDelivery { get; set; }
        [JsonIgnore]
        public MailTypes? MailTypeEnum
        {
            get
            {
                var valusEnum = EnumHelper.GetValues<MailTypes>();
                foreach (var mt in valusEnum)
                {
                    if(mt.GetEnumString() == MailType)
                    {
                        return mt;
                    }
                }
                return null;
            }
        }
        [JsonIgnore]
        public MailCtg? MailCtgEnum
        {

            get
            {
                var valusEnum = EnumHelper.GetValues<MailCtg>();
                foreach (var mt in valusEnum)
                {
                    if (mt.GetEnumString() == MailCategory)
                    {
                        return mt;
                    }
                }
                return null;
            }
        }
        [JsonIgnore]
        public MailRank? MailRankEnum
        {

            get
            {
                var valusEnum = EnumHelper.GetValues<MailRank>();
                foreach (var mt in valusEnum)
                {
                    if (mt.GetEnumString() == MailRank)
                    {
                        return mt;
                    }
                }
                return null;
            }
        }
        [JsonIgnore]
        public TransTypes? TransEnum
        {

            get
            {
                var valusEnum = EnumHelper.GetValues<TransTypes>();
                foreach (var mt in valusEnum)
                {
                    if (mt.GetEnumString() == TransType)
                    {
                        return mt;
                    }
                }
                return null;
            }
        }
        [JsonIgnore]
        public List<PostMark> PostMarksEnum
        {
            get
            {
                if (PostMarks is null) return null;
                var rez = new List<PostMark>();

                foreach (var postMarks in PostMarks)
                {
                    var valusEnum = EnumHelper.GetValues<PostMark>();
                    foreach (var mt in valusEnum)
                    {
                        if (mt.GetEnumString() == postMarks)
                        {
                            rez.Add(mt);
                            break;
                        }
                    }
                }

                return rez;
               
            }
        }
    }
}