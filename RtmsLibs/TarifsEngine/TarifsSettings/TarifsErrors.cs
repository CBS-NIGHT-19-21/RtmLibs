using Newtonsoft.Json;
using RtmLib.TarifsEngine.TarifsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Ошибки при расчете тарифов
    /// </summary>
    public class TarifsErrors
    {
        /// <summary>
        /// Описание ошибки
        /// </summary>
        [JsonProperty("msg")]
        public string ErrorMassage { get; set; }
        /// <summary>
        /// Код ошибки
        /// </summary>
        [JsonProperty("code")]
        public int CodeError { get; set; }
        /// <summary>
        /// Тип ошибки
        /// </summary>
        [JsonProperty("type")]
        public TarifsErrorsType ErrorCodeType { get; set; }
    }
}
