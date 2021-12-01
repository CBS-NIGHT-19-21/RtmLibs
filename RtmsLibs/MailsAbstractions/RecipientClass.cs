using RtmLib.Addresses;
using RtmLib.TarifsEngine.TarifsSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.MailsAbstractions
{
    /// <summary>
    /// Получатель отпралвения
    /// </summary>
    public class RecipientClass
    {
        /// <summary>
        /// Имя получателя
        /// </summary>
        public string RecipientName { get; set; }
        /// <summary>
        /// Адрес получателя
        /// </summary>
        public AddressRtm AddressRcpn { get; set; }
        /// <summary>
        /// Флаг на то является ли получатель юр лицом
        /// </summary>
        public bool IsOrg { get; set; }
        /// <summary>
        /// Телефон получателя
        /// </summary>
        public string TelRcpn { get; set; }
        /// <summary>
        /// Страна назначения получателя
        /// </summary>
        public TarifsCountryClass CountryRcpn { get; set; }

    }
}
