using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RtmLib.Barcodes;
using RtmLib.CheckSpi.CheckSpiEntr.Enums;
using RtmLib.CheckSpi.CheckSpiEntr.JsonAnsvers;
using RtmLib.CheckSpi.CheckSpiEntr.Specials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.CheckSpi
{
    /// <summary>
    /// Отслеживание РПО с помощью сайта Почта Ру
    /// </summary>
    public class ChekerEngine
    {
        public static DataFromJson[] ValuesFromAdminTools
        {
            get
            {
                try
                {
                    var apthSpec = Path.Combine(Directory.GetCurrentDirectory(), "OperationEnums.json");
                    var rez = JsonConvert.DeserializeObject<DataFromJson[]>(File.ReadAllText(apthSpec, Encoding.UTF8));
                    return rez;
                }
                catch
                {

                    return null;
                }
            }
            
        }

        private readonly HttpClient _client = new HttpClient();
        /// <summary>
        /// Получаем запрос на проверку ШПИ
        /// </summary>
        /// <param name="barcodeName">ШПИ</param>
        /// <returns></returns>
        public static string GetUrlToCheckSpi(string barcodeName) => $"https://www.pochta.ru/tracking?p_p_id=trackingPortlet_WAR_portalportlet&p_p_lifecycle=2&p_p_state=normal&p_p_mode=view&p_p_resource_id=tracking.get-by-barcodes&p_p_cacheability=cacheLevelPage&p_p_col_id=column-1&p_p_col_count=1&barcodes={barcodeName}";
        /// <summary>
        /// Получаем запрос на проверку ШПИ
        /// </summary>
        /// <param name="barcodeName">ШПИ в классе <see cref="BarcodeClass"/></param>
        /// <returns></returns>
        public static string GetUrlToCheckSpi(BarcodeClass barcodeName) => $"https://www.pochta.ru/tracking?p_p_id=trackingPortlet_WAR_portalportlet&p_p_lifecycle=2&p_p_state=normal&p_p_mode=view&p_p_resource_id=tracking.get-by-barcodes&p_p_cacheability=cacheLevelPage&p_p_col_id=column-1&p_p_col_count=1&barcodes={barcodeName.BarcodeString}";
        /// <summary>
        /// Получаем адрес для логина на внутернний портал
        /// </summary>
        /// <returns></returns>
        public static string GetUrlToPortalLogin() => $"https://trackadmin.tools.russianpost.ru/login";
        public static string GetUrlToGetSpiHystoryMaxPrev(string barcode) => $"https://trackadmin.tools.russianpost.ru/api/v1/barcode/{barcode}/history?verbose=false&opm=true";
        /// <summary>
        /// Получаем данные по информации
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<CheckSpiClass> GetBarcodeCheckAsync(string barcode)
        {
            try
            {
                var resoult = await _client.GetAsync(GetUrlToCheckSpi(barcode));
                var stringResoult = await resoult.Content.ReadAsStringAsync();
                if (resoult.IsSuccessStatusCode)
                {
                    var rezoult = JsonConvert.DeserializeObject<CheckSpiClass>(stringResoult);
                    return rezoult;
                }
                else
                {
                    throw new HttpRequestException($"Ошибка при выполнении запроса: {resoult.StatusCode} {stringResoult}");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Делаем логин на сайт с ШПИ
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        public async Task<bool> LgoginMaxPrev(string userName, string password)
        {
            //var contentString = JsonConvert.SerializeObject(new { username = userName, password = password });
            //var contentMassage = new StringContent(contentString);
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password)
            });
            //contentMassage.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                var resoinse = await _client.PostAsync(GetUrlToPortalLogin(), formContent);
                var responseMassage = await resoinse.Content.ReadAsStringAsync();
                if (responseMassage.Contains("Неверное имя пользователя или пароль"))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }
        /// <summary>
        /// Получаем ответ по ШПИ
        /// </summary>
        /// <returns></returns>
        public async Task<ChekcSpiResponse> GetSpiHystory(string barcode)
        {
            try
            {
                var resoinse = await _client.GetAsync(GetUrlToGetSpiHystoryMaxPrev(barcode));
                var responseMassage = await resoinse.Content.ReadAsStringAsync();
                var resoult = JsonConvert.DeserializeObject<ChekcSpiResponse>(responseMassage, new SpecialDateTimeConverter());
                return resoult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
