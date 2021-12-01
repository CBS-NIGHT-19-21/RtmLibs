using Newtonsoft.Json;
using RtmLib.Rtm002Check;
using RtmLib.Rtm002Lib;
using System;
using System.Collections.Generic;

namespace RtmLib.CheckSpi
{
    /// <summary>
    /// Данные по трекингу
    /// </summary>
    public  class TrackingItemsClass
    {
        [JsonProperty("lastOperationDateTime")]
        public string LasOperationTime { get; set; }
        [JsonProperty("acceptanceOperationDateTime")]
        public string AcceptedOperationTime { get; set; }
        [JsonProperty("firstOperationDate")]
        public string FirstOperationTime { get; set; }
        [JsonProperty("lastOperationDate")]
        public string LastOperationTime { get; set; }
        [JsonProperty("destinationCountryName")]
        public string DestCountyName { get; set; }
        [JsonProperty("destinationCityName")]
        public string DestCityName { get; set; }
        [JsonProperty("originCountryName")]
        public string SenderCountyName { get; set; }
        [JsonProperty("originCityName")]
        public string SenderCityName { get; set; }
        [JsonProperty("postMark")]
        public long PostMarkInt { get; set; }
        [JsonProperty("mailRank")]
        public int MailRankCheck { get; set; }
        [JsonProperty("mailCtg")]
        public int MailCtgCheck { get; set; }
        [JsonProperty("mailTypeCode")]
        public int MailTypeCheck { get; set; }
        [JsonProperty("weight")]
        public int WightDel { get; set; }
        [JsonProperty("recipient")]
        public string RecipientName { get; set; }
        [JsonProperty("sender")]
        public string SenderName { get; set; }
        [JsonProperty("barcode")]
        public string BarcodeName { get; set; }
        [JsonProperty("title")]
        public string TitleDel { get; set; }
        [JsonProperty("indexFrom")]
        public string IndexFrom { get; set; }
        [JsonProperty("indexTo")]
        public string IndexTo { get; set; }
        [JsonProperty("countryFromCode")]
        public int CountryFromCode { get; set; }
        [JsonProperty("countryToCode")]
        public int CountryToCode { get; set; }
        [JsonProperty("futurePathList")]
        public PathDeliverity[] PathInfos { get; set; }
        [JsonProperty("trackingHistoryItemList")]
        public PathDeliverity[] TrackingHistoryItemList { get; set; }
        /// <summary>
        /// Получаме postMarsk
        /// </summary>
        [JsonIgnore]
        public List<PostMark> PostMarks 
        { 
            get 
            {
                if (PostMarkInt > 0) return PostMarksHelper.IsContainsValues(PostMarkInt);
                else return null;
            } 
        }
        /// <summary>
        /// Категория отправлния в формате <see cref="MailCtg"/>
        /// </summary>
        [JsonIgnore]
        public MailCtg? MailCtgEnum
        {
            get
            {
                try
                {
                    return MailCtgCheck.GetTypeMailCtgByCode();
                }
                catch
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// Тип отправлния в формате <see cref="MailTypes"/>
        /// </summary>
        [JsonIgnore]
        public MailTypes? MailTypesEnum
        {
            get
            {
                try
                {
                    return MailTypeCheck.GetTypeMailTypeByCode();
                }
                catch
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// Ранк отправлния в формате <see cref="MailRank"/>
        /// </summary>
        [JsonIgnore]
        public MailRank? MailRankEnum
        {
            get
            {
                try
                {
                    return MailRankCheck.GetTypeMailRankByCode();
                }
                catch
                {

                    return null;
                }
            }
        }
    }
}