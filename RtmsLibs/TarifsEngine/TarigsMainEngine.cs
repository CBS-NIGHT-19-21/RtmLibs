using Newtonsoft.Json;
using RtmLib.TarifsEngine.TarifsAddresses;
using RtmLib.TarifsEngine.TarifsSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine
{
    public class TarigsMainEngine
    {
        private readonly HttpClient _client = new HttpClient();
        /// <summary>
        /// Получаем тариф
        /// </summary>
        /// <param name="queryString">Строка зпроса для тарификатора</param>
        /// <returns></returns>
        public async Task<TarifsData> GetTarifs(string queryString)
        {
            try
            {
                var response = await _client.GetAsync(queryString);
                var reoutlResponse = await response.Content.ReadAsStringAsync();
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resoult = JsonConvert.DeserializeObject<TarifsData>(reoutlResponse);
                    return resoult;
                }
                else 
                {
                    try
                    {
                        var resoult = JsonConvert.DeserializeObject<TarifsData>(reoutlResponse);
                        return resoult;
                    }
                    catch (Exception internalEx)
                    {
                        throw new HttpRequestException($"Ошибка при запросе: {internalEx}");
                    }
                    throw new HttpRequestException($"Ошибка при запросе: {reoutlResponse}");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Получаем списки стран как помощь в наборе данных
        /// </summary>
        /// <returns></returns>
        public async Task<CountryQuery> GetCountryHelper()
        {
            try
            {
                var response = await _client.GetAsync(TarifsAddress.UrlTarifCountry);
                var reoutlResponse = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resoult = JsonConvert.DeserializeObject<CountryQuery>(reoutlResponse);
                    return resoult;
                }
                else
                {
                    throw new HttpRequestException($"Ошибка при запросе: {reoutlResponse}");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Получаем списки услуг как помощь в наборе данных
        /// </summary>
        /// <returns></returns>
        public async Task<ServicesQuery> GetServiceHelper()
        {
            try
            {
                var response = await _client.GetAsync(TarifsAddress.UrlGetService);
                var reoutlResponse = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resoult = JsonConvert.DeserializeObject<ServicesQuery>(reoutlResponse);
                    return resoult;
                }
                else
                {
                    throw new HttpRequestException($"Ошибка при запросе: {reoutlResponse}");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
