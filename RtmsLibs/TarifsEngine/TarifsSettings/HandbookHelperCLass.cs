using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Значение справочника
    /// </summary>
    public class HandbookHelperCLass
    {
        /// <summary>
        /// Код значения. Обязательно
        /// </summary>
        [JsonProperty("id")]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Название значения. Опционально
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
