using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.MailsAbstractions
{
    /// <summary>
    /// Данные по габаритам отпралвения
    /// </summary>
    public class GabaritsClass
    {
        /// <summary>
        /// Длина отправления в сантиметрах (для отправлений EMS, КПО-стандарт, КПО-эконом). 
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Ширина отправления в сантиметрах (для отправлений EMS, КПО-стандарт, КПО-эконом).
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Высота отправления в сантиметрах (для отправлений EMS, КПО-стандарт, КПО-эконом).
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Объемный вес отправления в граммах (для отправлений EMS, КПО-эконом).
        /// </summary>
        public int VolumeWeight { get; set; }


    }
}
