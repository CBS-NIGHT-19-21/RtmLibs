using RtmLib.Rtm002Lib;
using RtmLib.Rtm003Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Addresses
{
    /// <summary>
    /// Класс для проверки адресов и прочей ерунды
    /// </summary>
    public static class StaticAdressesHelpers
    {
        /// <summary>
        /// Получить адрес для формирования РТМ
        /// </summary>
        /// <param name="address">Адресс</param>
        /// <returns></returns>
        public static string GetAddressSender(this AddressRtm address)
        {
            return 
                $"AddressTypeSndr={address.AddressTypeTo.GetEnumCode()}\n" +
                $"NumAddressTypeSndr={address.NumAddressTypeTo}\n" +
                $"IndexSndr={address.IndexTo.AddressString}\n" +
                $"RegionSndr={address.RegionTo}\n" +
                $"AreaSndr={address.AreaTo}\n" +
                $"PlaceSndr={address.PlaceTo}\n" +
                $"LocationSndr={address.LocationTo}\n" +
                $"StreetSndr={address.StreetTo}\n" +
                $"HouseSndr={address.HouseTo}\n" +
                $"LetterSndr={address.LetterTo}\n" +
                $"SlashSndr={address.SlashTo}\n" +
                $"CorpusSndr={address.CorpusTo}\n" +
                $"BuildingSndr={address.BuildingTo}\n" +
                $"HotelSndr={address.HotelTo}\n" +
                $"RoomSndr={address.RoomTo}\n";
        }
        /// <summary>
        /// Получить адрес для формирования списка отправлений
        /// </summary>
        /// <param name="address">Адресс</param>
        /// <returns></returns>
        public static string GetAddressRtmEntryThreeTwenty(this AddressRtm address)
        {
            return $"{address.AddressTypeTo.GetEnumCode()}|" +
                $"{address.NumAddressTypeTo}|" +
                $"{address.IndexTo.AddressString}|" +
                $"{address.RegionTo}|" +
                $"{address.AreaTo}|" +
                $"{address.PlaceTo}|" +
                $"{address.LocationTo}|" +
                $"{address.StreetTo}|" +
                $"{address.HouseTo}|" +
                $"{address.LetterTo}|" +
                $"{address.SlashTo}|" +
                $"{address.CorpusTo}|" +
                $"{address.BuildingTo}|"+
                $"{address.HotelTo}|" +
                $"{address.RoomTo}";
        }
        /// <summary>
        /// Получить сумму 
        /// </summary>
        /// <param name="marks"></param>
        /// <returns></returns>
        public static long GetPostMarksSumm(this List<PostMark> marks)
        {
            long res = 0;
            marks.ForEach(x=>res += x.GetEnumCode());
            return res;
        }

    }
}
