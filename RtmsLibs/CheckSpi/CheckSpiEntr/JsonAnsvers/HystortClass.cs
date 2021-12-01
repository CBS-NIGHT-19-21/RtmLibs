using Newtonsoft.Json;
using RtmLib.Rtm002Lib;
using System;
using System.IO;

namespace RtmLib.CheckSpi.CheckSpiEntr.JsonAnsvers
{
    /// <summary>
    /// Иторические данные по отправлению
    /// </summary>
    public class HystortClass
    {
        [JsonProperty("id")]
        public IdClassCheck IdHistory { get; set; }
        [JsonProperty("mass")]
        public long? Mass { get; set; }
        [JsonProperty("declaredWeight")]
        public long? DeclaredWeight { get; set; }
        [JsonProperty("volumeWeight")]
        public long? VolumeWeight { get; set; }
        [JsonProperty("value")]
        public long? Value { get; set; }
        [JsonProperty("payment")]
        public long? Payment { get; set; }
        [JsonProperty("compulsoryPayment")]
        public long? CompulsoryPayment { get; set; }
        [JsonProperty("insrRate")]
        public long? InsrRate { get; set; }
        [JsonProperty("totalMassRate")]
        public long? TotalMassRate { get; set; }
        [JsonProperty("customDuty")]
        public string CustomDuty { get; set; }
        [JsonProperty("destIndex")]
        public string DestIndex { get; set; }
        [JsonProperty("destAddress")]
        public string DestAddress { get; set; }
        [JsonProperty("internum")]
        public string Internum { get; set; }
        [JsonProperty("incomeDate")]
        public DateTime IncomeDate { get; set; }
        [JsonProperty("loadDate")]
        public DateTime LoadDate { get; set; }
        [JsonProperty("softwareName")]
        public string SoftwareName { get; set; }
        [JsonProperty("softwareVersion")]
        public string SoftwareVersion { get; set; }
        [JsonProperty("dataProvider")]
        public string DataProvider { get; set; }
        [JsonProperty("phoneRecipient")]
        public string PhoneRecipient { get; set; }
        [JsonProperty("phoneSender")]
        public string PhoneSender { get; set; }
        [JsonProperty("mailCategory")]
        public int? MailCategory { get; set; }

        [JsonIgnore]
        public MailCtg? MailCtgEnum
        {
            get
            {
                if(MailCategory.HasValue)
                {
                    try
                    {
                        return MailCategory.Value.GetTypeMailCtgByCode();
                    }
                    catch
                    {
                        return null;
                    }
                }
                return null;
            }
        }


        [JsonProperty("mailType")]
        public int? MailType { get; set; }
        [JsonIgnore]
        public MailTypes? MailTypeEnum
        {
            get
            {
                if (MailCategory.HasValue)
                {
                    try
                    {
                        return MailType.Value.GetTypeMailTypeByCode();
                    }
                    catch
                    {
                        return null;
                    }
                }
                return null;
            }
        }
        [JsonProperty("sendPrice")]
        public long? SendPrice { get; set; }
        [JsonProperty("sendAirPrice")]
        public long? SendAirPrice { get; set; }
        [JsonProperty("additionalTariff")]
        public long? AdditionalTariff { get; set; }
        [JsonProperty("transType")]
        public string TransType { get; set; }
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
        [JsonProperty("smsInformation")]
        public object SmsInformation { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("hideReason")]
        public string HideReason { get; set; }
        [JsonProperty("operDate")]
        public DateTime OperDate { get; set; }

        [JsonProperty("operType")]
        public int? OperType { get; set; }
        [JsonIgnore]
        public string OperTypeString
        {
            get
            {
                if(OperType.HasValue)
                {
                    try
                    {
                        if(!(ChekerEngine.ValuesFromAdminTools is null))
                        {
                            foreach (var item in ChekerEngine.ValuesFromAdminTools)
                            {
                                if (item.RootIndex == OperType.Value) return item.RootName;
                            }
                        }
                        return null;
                    }
                    catch 
                    {

                        return null;
                    }
                }
                return null;
            }
        }


        [JsonProperty("operAttr")]
        public int? OperAttr { get; set; }
        [JsonIgnore]
        public string OperAttrString
        {
            get
            {
                if (OperAttr.HasValue)
                {
                    try
                    {
                        if (!(ChekerEngine.ValuesFromAdminTools is null))
                        {
                            foreach (var item in ChekerEngine.ValuesFromAdminTools)
                            {
                                if (item.RootIndex == OperType.Value)
                                {
                                    foreach (var itemRootChild in item.RootChilds)
                                    {
                                        if (itemRootChild.RootChildIndex == OperAttr.Value) return itemRootChild.RootChildName;
                                    }
                                }
                            }
                        }
                        return null;
                    }
                    catch
                    {
                        return null;
                    }
                }
                return null;
            }
        }
        [JsonProperty("operIndex")]
        public string OperIndex { get; set; }
        [JsonProperty("operAddress")]
        public string OperAddress { get; set; }
        [JsonProperty("operDateOffset")]
        public long? OperDateOffset { get; set; }
        [JsonProperty("NDS")]
        public object Nds { get; set; }

    }
}