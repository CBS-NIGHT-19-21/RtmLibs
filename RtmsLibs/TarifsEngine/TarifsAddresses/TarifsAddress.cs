using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsAddresses
{
    /// <summary>
    /// Данные по адресам для тарификации
    /// </summary>
    public static class TarifsAddress
    {
        #region HelpersQuery
        /// <summary>
        /// Запрос на получение стран для тарификатора
        /// </summary>
        public static string UrlTarifCountry => "https://tariff.pochta.ru/tariff/v2/dictionary?jsontext&country";
        /// <summary>
        /// Запрос на получение услуг для тарификатора
        /// </summary>
        public static string UrlGetService => "https://tariff.pochta.ru/tariff/v2/dictionary?jsontext&service"; 
        #endregion
        /// <summary>
        /// Начальный запрос на тарификацию (для составление запроса на расчет тарифов)
        /// </summary>
        public static string UrlTarifCalculateBase => "https://tariff.pochta.ru/tariff/v1/calculate?";
        // Тестовый запрос на тарификацию письма
        //https://tariff.pochta.ru/tariff/v1/calculate?from=644050&weight=20&sumoc=0&date=20211013&dogovor=55-5507209256-7.4.1.1-06/1475&to=644046&html&errorcode=0&typ=2&dir=0&closed=1&cat=1

    }
}
