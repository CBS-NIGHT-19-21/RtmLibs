using Newtonsoft.Json;
using System;

namespace RtmLib.CheckSpi.CheckSpiEntr.JsonAnsvers
{
    /// <summary>
    /// Данные по Id шага отправления
    /// </summary>
    public class IdClassCheck
    {
        [JsonProperty("shipmentId")]
        public string ShipmentId { get; set; }
        [JsonProperty("operDate")]
        public DateTime OperDate { get; set; }
        [JsonProperty("operType")]
        public int? OperType { get; set; }
        [JsonIgnore]
        public string OperTypeString
        {
            get
            {
                if (OperType.HasValue)
                {
                    try
                    {
                        if (!(ChekerEngine.ValuesFromAdminTools is null))
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
        [JsonProperty("indexOper")]
        public string IndexOper { get; set; }
    }
}