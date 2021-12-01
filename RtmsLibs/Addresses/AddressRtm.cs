using RtmLib.Attributes;
using RtmLib.Rtm002Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RtmLib.Addresses
{
    /// <summary>
    /// Класс нормализованного адреса 
    /// </summary>
    public class AddressRtm
    {
        /// <summary>
        /// Индекс места назначения
        /// </summary>
        [Required]
        public AddressElement IndexTo { get; set; }
        /// <summary>
        /// Область, регион места назначения РПО.
        /// </summary>
        [Required]
        public AddressElement RegionTo { get; set; }
        /// <summary>
        /// Район места назначения РПО.
        /// </summary>
        public AddressElement AreaTo { get; set; }
        /// <summary>
        /// Населенный пункт места назначения РПО.
        /// </summary>
        [Required]
        public AddressElement PlaceTo { get; set; }
        /// <summary>
        /// Внутригородской элемент (квартал, спутник, поселение, микрорайон, территория).
        /// </summary>
        public AddressElement LocationTo { get; set; }
        /// <summary>
        /// Часть адреса. Наименование улицы места назначения РПО.
        /// </summary>
        public AddressElement StreetTo { get; set; }
        /// <summary>
        /// Часть адреса. Номер здания.  Обязательно для заполнения при указании типов адреса: «стандартный», «гостиница».
        /// </summary>
        public AddressElement HouseTo { get; set; }
        /// <summary>
        /// Часть здания. Литера.
        /// </summary>
        public AddressElement LetterTo { get; set; }
        /// <summary>
        /// Часть здания. Дробь.
        /// </summary>
        public AddressElement SlashTo { get; set; }
        /// <summary>
        /// Часть здания. Корпус.
        /// </summary>
        public AddressElement CorpusTo { get; set; }
        /// <summary>
        /// Часть здания. Строение.
        /// </summary>
        public AddressElement BuildingTo { get; set; }
        /// <summary>
        /// Название гостиницы.
        /// </summary>
        public AddressElement HotelTo { get; set; }
        /// <summary>
        /// Часть здания. Номер помещения.
        /// </summary>
        public AddressElement RoomTo { get; set; }
        /// <summary>
        /// Тип адреса Возможные значения:
        /// 1- стандартный;
        /// 2- а/я;
        /// 3- до востребования;
        /// 4- войсковая часть;
        /// 5- гостиница;
        /// 6- войсковая часть ЮЯ;
        /// 7- полевая почта.
        /// </summary>
        public AddressType AddressTypeTo { get; set; }
        /// <summary>
        /// Номер соответствующего типа адреса Обязательно для заполнения при указании типов адреса: «а/я», «войсковая часть», «войсковая часть ЮЯ», «полевая почта». Для стандартного типа адреса поле не заполняется.
        /// </summary>
        [MaxLength(15, ErrorMessage = "Максимальная длина должна быть менеее или равна 15 числовых символов")]
        [RegularExpression(@"\d{0,15}",
         ErrorMessage = "Не соответствует маске атрибута")]
        public string NumAddressTypeTo { get; set; }

        public override string ToString()
        {
            if (AddressTypeTo != AddressType.Стандратный_Адрес)
                return $"{ AddressTypeTo } { NumAddressTypeTo }";
            return $"{ IndexTo } { RegionTo } { AreaTo } { PlaceTo } { LocationTo } { StreetTo } { HouseTo }";
        }


    }
}
