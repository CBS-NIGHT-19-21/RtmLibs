using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Запрос на получение списка услуг для тарификации
    /// </summary>
    public class ServicesQuery
    {
        /// <summary>
        /// Версия сервиса
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
        /// <summary>
        /// Список услуг (кодов и наименований)
        /// </summary>
        [JsonProperty("service")]
        public ServiseTarifClass[] Servises { get; set; }
    }
}
