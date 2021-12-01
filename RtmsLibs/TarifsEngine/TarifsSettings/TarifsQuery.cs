using RtmLib.Attributes;
using RtmLib.Rtm002Lib;
using RtmLib.TarifsEngine.TarifsAddresses;
using RtmLib.TarifsEngine.TarifsEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Запрос на расчет тарифа
    /// </summary>
    public class TarifsQuery
    {
        /// <summary>
        /// Указание на формат данных в ответе
        /// </summary>
        [Required]
        public TarifsQuerySettingsEnum TarifOutputFormat { get; set; } = TarifsQuerySettingsEnum.json;
        /// <summary>
        /// Параметр на возвращаемю ошибку в запросе (при возникновении ошибки)
        /// </summary>
        [Required]
        public ErrorCodeQueryEnum ErrorCodeQuery { get; set; } = ErrorCodeQueryEnum.ErrorCode;
        /// <summary>
        /// Объект по запросу
        /// Не реалзиовано так как для запроса по РТМ планирую использовать связку MailCtg и MailType
        /// </summary>
        public int? Object { get; set; }
        /// <summary>
        /// Тип почтового отправления
        /// </summary>
        public MailTypes? MailTypeEnum { get; set; }
        /// <summary>
        /// Категория почтового отправления
        /// </summary>
        public MailCtg? MailCtgEnum { get; set; }
        /// <summary>
        /// Направление доставки отправления
        /// </summary>
        public DirectCtg? DirectCtgEnum { get; set; }
        /// <summary>
        /// Дата тарификации и дата расчета контрольных сроков
        /// </summary>
        public DateTime? DateDelivery { get; set; } = DateTime.Now;
        /// <summary>
        /// Время начала отсчета контрольных сроков доставки
        /// </summary>
        public TimeSpan? TimeDelivery { get; set; }
        /// <summary>
        /// Признак возможности или невозможности расчета во временно закрытый для доставки период
        /// </summary>
        public ClosedPerDeliveryEnum? ClosedPostOffice { get; set; }
        /// <summary>
        /// Индекс места отпралвения ОПС
        /// </summary>
        [IndexOps]
        public string IndexOpsFrom { get; set; }
        /// <summary>
        /// Почтовый индекс места назначения
        /// </summary>
        [IndexOps]
        public string IndexOpsTo { get; set; }
        /// <summary>
        /// Страна назначения для международных исходящих отправлений (из справочника по странам)
        /// </summary>
        public TarifsCountryClass CountryTo { get; set; }
        /// <summary>
        /// Страна приема для международных входящих отправлений (из справочника по странам)
        /// </summary>
        public TarifsCountryClass CountryFrom { get; set; }
        /// <summary>
        /// Код региона по Конституции РФ для тарификации услуг. При тарификации отправления параметр игнорируется
        /// </summary>
        public int? Region { get; set; }
        /// <summary>
        /// Вес отправления. Указывается в граммах
        /// </summary>
        public int? Weight { get; set; }
        /// <summary>
        /// Сумма объявленной ценности в копейках 
        /// Обязательно для 2 и 4 категорий отправления, см. РТМ-2
        /// </summary>
        public int? Sumoc { get; set; }
        /// <summary>
        /// Сумма наложенного платежа в копейках Используется  при тарификации переводов наложенного платежа.
        /// При указании сумма НП сравнивается c суммой ОЦ (если сумма НП больше, выводится сообщение об ошибке)
        /// Обязательно для 4 категорий отправления, см. РТМ-2
        /// </summary>
        public int? Sumnp { get; set; }
        /// <summary>
        /// Сумма гарантии отправления в копейках
        /// </summary>
        public int? Sumgs { get; set; }

        /*
         * Дальше должны идти даные для расчета страховых и прочих услуг 
         * прочей корреконденциии и предоставляемых ПР улсуг
         * Нам в данной библиотеке пока не нужно это
         * так что я оставлю без реализации
         * Более подробно в РТМ на тарификатора
         */
        /// <summary>
        /// Догоовр с корпоративным клиентом
        /// </summary>
        public DogovorQueryClass Dogovor { get; set; }
        /// <summary>
        /// Предпочтительный вариант доставки
        /// </summary>
        public TarifsSenderHelper? PreferDeliv { get; set; }
        /// <summary>
        /// Список услуг для расчета тарифа
        /// </summary>
        public List<ServiseTarifClass> Servises { get; set; }
        /// <summary>
        /// Отметки внутренних и международных отправлений
        /// </summary>
        public List<PostMark> PostMarks { get; set; }
        /// <summary>
        /// Код разряда почтового отправления, согласно РТМ-2
        /// </summary>
        public MailRank? MailRuncQuery { get; set; }
        /// <summary>
        /// Получить строку запроса на тарификатор
        /// </summary>
        public string QueryString => GetQueryString();

        /// <summary>
        /// Формируем запрос на отправку данных для тарифа
        /// </summary>
        /// <returns>Строка зпароса для отправки в Engine</returns>
        private string GetQueryString()
        {

            CheckQury();

            string baseString = TarifsAddress.UrlTarifCalculateBase;
            baseString += TarifOutputFormat.ToString();
            baseString +=
                $"&errorcode={(int)ErrorCodeQuery}" +
                $"{(Object is null ? "" : $"&object={Object}")}" +
                $"{(MailTypeEnum is null ? "" : $"&mailtype={MailTypeEnum.Value.GetEnumCode()}")}" +
                $"{(MailCtgEnum is null ? "" : $"&mailctg={MailCtgEnum.Value.GetEnumCode()}")}" +
                $"{(DirectCtgEnum is null ? "" : $"&directctg={DirectCtgEnum.Value.GetEnumCode(out bool _)}")}" +
                $"&date={DateDelivery:yyyyMMdd}" +
                $"{(TimeDelivery is null ? "" : $"&directctg={TimeDelivery.Value:hms)}")}" +
                $"{(ClosedPostOffice is null ? "" : $"&closed={(int)ClosedPostOffice.Value}")}" +
                $"{(IndexOpsFrom is null ? "" : $"&from={IndexOpsFrom}")}" +
                $"{(IndexOpsTo is null ? "" : $"&to={IndexOpsTo}")}" +
                $"{(CountryTo is null ? "" : $"&country-to={CountryTo.Id}")}" +
                $"{(CountryFrom is null ? "" : $"&country-from={CountryTo.Id}")}" +
                $"{(Region is null ? "" : $"&region={Region.Value}")}" +
                $"{(Weight is null ? "" : $"&weight={Weight.Value}")}" +
                $"{(Sumoc is null ? "" : $"&sumoc={Sumoc.Value}")}" +
                $"{(Sumgs is null ? "" : $"&sumgs={Sumgs.Value}")}" +
                $"{(Dogovor is null ? "" : $"&dogovor={Dogovor}")}" +
                $"{(PreferDeliv is null ? "" : $"&isavia={(int)PreferDeliv.Value}")}" +
                $"{(PostMarks is null ? "" : $"&postmark={GetPostMarkVal(PostMarks)}")}" +
                $"{(Servises is null ? "" : $"&service={GetValuesString(Servises)}")}" +
                $"{(MailRuncQuery is null ? "" : $"&mailrank={MailRuncQuery.Value.GetEnumCode()}")}";
            baseString = baseString.Trim('&');
            baseString = baseString.Trim();
            return baseString;
        }

        private void CheckQury()
        {
            
        }

        private string GetValuesString(List<ServiseTarifClass> valuiesCollection)
        {
            var resoult = "";
            foreach(var item in valuiesCollection)
            {
                resoult += $",{item.Id}";
            }
            resoult = resoult.Trim(',');
            return resoult;
        }
        /// <summary>
        /// Проверяем службы по PostMark
        /// </summary>
        public void CheckServises(IEnumerable<ServiseTarifClass> servises)
        {
            foreach (var item in PostMarks)
            {
                var serviseCheck = servises.Where(x => x.Mark == item.GetEnumCode()).FirstOrDefault();
                if (!(serviseCheck is null))
                {
                    if (Servises is null)
                    {
                        Servises = new List<ServiseTarifClass>();
                    }
                    if (!Servises.Contains(serviseCheck))
                    {
                        Servises.Add(serviseCheck);
                    }
                }

            }
        }
        private long GetPostMarkVal(List<PostMark> valueCollection)
        {
            long resoult = 0;
            foreach (var item in valueCollection)
            {
                resoult += item.GetEnumCode();
            }
            return resoult;
        }
        
    }



}
