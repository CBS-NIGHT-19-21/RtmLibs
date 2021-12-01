using RtmLib.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Если запрос делается по договору то этот класс как раз его реализует
    /// </summary>
    public class DogovorQueryClass
    {
        /// <summary>
        /// Инн договора
        /// </summary>
        [Inn]
        [Required]
        public string Inn { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        [Required]
        public string DogNumber { get; set; }
        /// <summary>
        /// Id ругиона (например 55 - Омск)
        /// </summary>
        [Required]
        public int RegionId { get; set; }
        public override string ToString()
        {
            return $"{RegionId}-{Inn}-{DogNumber}";
        }
    }
}
