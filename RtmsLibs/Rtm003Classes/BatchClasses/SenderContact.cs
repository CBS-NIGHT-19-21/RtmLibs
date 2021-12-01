using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Classes.BatchClasses
{
    /// <summary>
    /// Контактные данные отправителя 
    /// </summary>
    public class SenderContact
    {
        /// <summary>
        /// Телефон(ы) отправтеля
        /// </summary>
        public string[] TelSender { get; set; }
        /// <summary>
        /// Емеил(ы) отправителя
        /// </summary>
        public string[] EmailSender { get; set; }
    }
}
