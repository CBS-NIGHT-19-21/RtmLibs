using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Коды стран пересылки почтовых отправлений
    /// </summary>
    public class TarifsCountryClass
    {
        /// <summary>
        /// Код страны
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Наименование страны пересылки
        /// </summary>
        [JsonProperty("name")]
        public string CountryNameRussia { get; set; }
        /// <summary>
        /// Список услуг для письменной корреспонденции
        /// </summary>
        [JsonProperty("k")]
        public CountryServises CountryServisesMails { get; set; }
        /// <summary>
        /// Список услуг для посылок
        /// </summary>
        [JsonProperty("p")]
        public CountryServises CountryServisesPack { get; set; }
        /// <summary>
        /// tag
        /// </summary>
        [JsonProperty("tag")]
        public string[] Tags { get; set; }
        public override string ToString()
        {
            return CountryNameRussia;
        }
    }
}
