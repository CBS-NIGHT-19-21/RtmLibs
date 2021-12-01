using RtmLib.Addresses;
using RtmLib.Attributes;
using RtmLib.Rtm002Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Rtm003Classes.BatchClasses
{
    /// <summary>
    /// Данные по отправителю
    /// </summary>
    public class SenderClass
    {
        /// <summary>
        /// ФИО, данные об отправителе РПО. Sndr=отправитель, где отправитель – символьная строка.
        /// </summary>
        [Required(ErrorMessage ="Наименование отправителя необходимо")]
        [MinLength(1, ErrorMessage ="Минимальная длина должна быть более 1 символа")]
        [MaxLength(147, ErrorMessage ="Максимальная длина должна быть менеее или равна 147 символов")]
        public string SenderName { get; set; }
        /// <summary>
        /// Адрес отправителя
        /// </summary>
        public AddressRtm SenderAddress { get; set; }
        /// <summary>
        /// Инн отправителя
        /// </summary>
        [Inn]
        public string Inn { get; set; }
        /// <summary>
        /// КПП отправителя
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// Отдельный код подразеления отправителя
        /// </summary>
        public string DepCodeSender { get; set; }
        /// <summary>
        /// Контактная информация отправителя
        /// </summary>
        public SenderContact SenderContacts { get; set; }
        /// <summary>
        /// Данные по контракту по отправителю
        /// </summary>
        public SenderContract Contracts { get; set; }
        /// <summary>
        /// Номер оегиона отправителя
        /// </summary>
        public int RegionSender { get; set; }
        /// <summary>
        /// Категория отправителя
        /// </summary>
        public SendCtg SenderCategory { get; set; }
    }
}
