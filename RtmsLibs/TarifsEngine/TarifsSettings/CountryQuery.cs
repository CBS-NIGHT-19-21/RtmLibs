using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Ответ от получения информации о странах
    /// по запросу правочника стран
    /// </summary>
    public class CountryQuery
    {
        /// <summary>
        /// Версия сервиса
        /// </summary>
        [JsonProperty("version")]
        public string Verison { get; set; }
        /// <summary>
        /// Дата получения справочной информации
        /// </summary>
        [JsonProperty("date")]
        public string DateCountryString { get; set; }
        /// <summary>
        /// В формате даты 
        /// </summary>
        [JsonIgnore]
        public DateTime DateContry => new DateTime(int.Parse(DateCountryString.Substring(0, 4)), int.Parse(DateCountryString.Substring(4, 2)), int.Parse(DateCountryString.Substring(6, 2)));
        /// <summary>
        /// Список стран
        /// </summary>
        [JsonProperty("country")]
        public TarifsCountryClass[] Countryes { get; set; }


    }
}
