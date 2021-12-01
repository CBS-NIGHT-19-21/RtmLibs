using Newtonsoft.Json;
using RtmLib.Rtm002Lib;
using RtmLib.TarifsEngine.TarifsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Выходные данные после обращения к тарификатору
    /// </summary>
    public class TarifsData
    {
        /// <summary>
        /// Версия сервиса
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
        /// <summary>
        /// Наименование сервиса
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// Массив сообщений об ошибке
        /// </summary>
        [JsonProperty("errors")]
        public TarifsErrors[] Errors { get; set; }
        /// <summary>
        /// Код объекта расчета
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Наименование объекта расчета
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Дата расчета в виде YYYYMMDD
        /// </summary>
        [JsonProperty("date")]
        public int Date { get; set; }
        /// <summary>
        /// Время начала отсчета контрольных сроков доставки в виде HHNNSS, где HH – часы NN – минуты, SS – секунды
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }
        /// <summary>
        /// Вид отправления, согласно РТМ-2
        /// </summary>
        [JsonProperty("typ")]
        public int MailTypeCode { get; set; }
        /// <summary>
        /// Категория отправления, согласно РТМ-2
        /// </summary>
        [JsonProperty("cat")]
        public int MailCtgCode { get; set; }
        /// <summary>
        /// Направление доставки отправления:
        /// </summary>
        [JsonProperty("dir")]
        public int DirectCtgCode { get; set; }
        /// <summary>
        /// Дата начала действия тарифа, в виде YYYYMMDD, где YYYY – год, MM – месяц, DD – день
        /// </summary>
        [JsonProperty("date-first")]
        public int DateStartTarif { get; set; }
        /// <summary>
        /// Дата окончания действия тарифа включительно, в виде YYYYMMDD, где YYYY – год, MM – месяц, DD – день
        /// </summary>
        [JsonProperty("date-last")]
        public int DateEndTarif { get; set; }
        /// <summary>
        /// Дата начала действия контрольных сроков, в виде YYYYMMDD, где YYYY – год, MM – месяц, DD – день
        /// </summary>
        [JsonProperty("delivery-datefirst")]
        public int DateStartContrDate { get; set; }
        /// <summary>
        /// Дата окончания действия контрольных сроков включитлеьно, в виде YYYYMMDD, где YYYY – год, MM – месяц, DD – день
        /// </summary>
        [JsonProperty("delivery-date-datelast")]
        public int DateEndContrDate { get; set; }
        /// <summary>
        /// Список составных частей расчета.
        /// </summary>
        [JsonProperty("items")]
        public ItemsClass[] Item { get; set; }
        /// <summary>
        /// Список почтовых объектов, принимающих участие в расчете
        /// </summary>
        [JsonProperty("postoffice")]
        public PostOfficeClass[] PostOffice { get; set; }
        /// <summary>
        /// Способ доставки по РТМ-2
        /// </summary>
        [JsonProperty("transid")]
        public int TransTypeCode { get; set; }
        /// <summary>
        /// Идентификатор запроса, передаваемый во входных параметрах
        /// </summary>
        [JsonProperty("reqid")]
        public string ReqId { get; set; }
        /// <summary>
        /// Почтовый индекс места отправления
        /// </summary>
        [JsonProperty("from")]
        public int FromIndex { get; set; }
        /// <summary>
        /// Почтовый индекс места назначения
        /// </summary>
        [JsonProperty("to")]
        public int ToIndex { get; set; }
        /// <summary>
        /// Страна назначения для международных исходящих отправлений, код по РТМ-2
        /// </summary>
        [JsonProperty("country-to")]
        public int ToCountry { get; set; }
        /// <summary>
        /// Страна приема для международных исходящих отправлений, код по РТМ-2
        /// </summary>
        [JsonProperty("country-from")]
        public int FromCountry { get; set; }
        /// <summary>
        /// Информация о стране назначения или о стране приема
        /// </summary>
        [JsonProperty("country")]
        public CountryClass Country { get; set; }
        /// <summary>
        /// Предпочтительный вариант доставки, запрошенный при расчете
        /// </summary>
        [JsonProperty("isavia")]
        public HandbookHelperCLass IsAvia { get; set; }
        /// <summary>
        /// Список кодов дополнительных услуг и вариантов расчета. Список, запрошенный при расчете
        /// </summary>
        [JsonProperty("isservice")]
        public int[] ServisesAdding { get; set; }
        /// <summary>
        /// Вариант расчета контрольного срока
        /// </summary>
        [JsonProperty("deliveryvariant")]
        public int DelyveryVariant { get; set; }
        /// <summary>
        /// Признак варианта расчета
        /// </summary>
        [JsonProperty("issize")]
        public IsSizeEnum IsSize { get; set; }
        /// <summary>
        /// Признак возможности тарификации группы отправлений
        /// </summary>
        [JsonProperty("isgroup")]
        public IsGroupEnum IsGroup { get; set; }
        /// <summary>
        /// Признак использования при расчете индивидуальных справочников договора
        /// </summary>
        [JsonProperty("isdogovor")]
        public IsDogovorEnum IsDogovor { get; set; }
        /// <summary>
        /// Договор в формате строки
        /// </summary>
        [JsonProperty("dogovor")]
        public string DogovorString { get; set; }
        /// <summary>
        /// Признак тарификации группы отправлений
        /// </summary>
        [JsonProperty("group")]
        public HandbookHelperCLass Group { get; set; }
        /// <summary>
        /// Трехзначное обозначение валюты расчета согласно ISO 4217
        /// </summary> 
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Код упаковки
        /// </summary> 
        [JsonProperty("packid")]
        public PackegeEnum Pack { get; set; }
        /// <summary>
        /// Вес в граммах
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }
        /// <summary>
        /// Сумма объявленной ценности в копейках
        /// </summary>
        [JsonProperty("sumoc")]
        public int Sumoc { get; set; }
        /// <summary>
        /// Сумма наложенного платежа в копейках
        /// </summary>
        [JsonProperty("sumnp")]
        public int Sumnp { get; set; }
        /// <summary>
        /// Сумма гарантии отправления в копейках
        /// </summary>
        [JsonProperty("sumgs")]
        public int Sumgs { get; set; }
        /// <summary>
        /// Страховая сумма / Сумма перевода в копейках. Указывается для услуг страхования и денежных переводов
        /// </summary>
        [JsonProperty("sum")]
        public int Sum { get; set; }
        /// <summary>
        /// Сумма платежа или вложения в копейках
        /// </summary>
        [JsonProperty("sumin")]
        public int Sumin { get; set; }
        /// <summary>
        /// Объем платежей в месяц в копейках
        /// </summary>
        [JsonProperty("sum_month")]
        public int SumMonth { get; set; }
        /// <summary>
        /// Период в месяцах страхования / абонирования ячейки для соответствующих услуг страхования и абонирования ячейки
        /// </summary> 
        [JsonProperty("month")]
        public int Month { get; set; }
        /// <summary>
        /// Размер отправления в сантиметрах Указывается как три целых числа, разделенные знаком "x"
        /// </summary> 
        [JsonProperty("size")]
        public string Size { get; set; }
        /// <summary>
        /// Количество: штук, слов, материалов или  размещений, в зависимости от объекта расчета
        /// </summary>  
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// Количество отправлений в группе, в зависимости от объекта расчета
        /// </summary>  
        [JsonProperty("countinpack")]
        public int Countinpack { get; set; }
        /// <summary>
        /// Тип клиента
        /// </summary>
        [JsonProperty("client")]
        public HandbookHelperCLass Client { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        [JsonProperty("region")]
        public HandbookHelperCLass Region { get; set; }
        /// <summary>
        /// Универсальные параметры Используются для различных объектов расчета. Значения зависят от объекта расчета
        /// </summary>
        [JsonProperty("p1")]
        public HandbookHelperCLass ParamOne { get; set; }
        /// <summary>
        /// Универсальные параметры Используются для различных объектов расчета. Значения зависят от объекта расчета
        /// </summary>
        [JsonProperty("p2")]
        public HandbookHelperCLass ParamTwo { get; set; }
        /// <summary>
        /// Универсальные параметры Используются для различных объектов расчета. Значения зависят от объекта расчета
        /// </summary>
        [JsonProperty("p3")]
        public HandbookHelperCLass ParamThree { get; set; }
        /// <summary>
        /// Универсальные параметры Используются для различных объектов расчета. Значения зависят от объекта расчета
        /// </summary>
        [JsonProperty("p4")]
        public HandbookHelperCLass ParamFour { get; set; }
        /// <summary>
        /// Универсальные параметры Используются для различных объектов расчета. Значения зависят от объекта расчета
        /// </summary>
        [JsonProperty("p5")]
        public HandbookHelperCLass ParamFive { get; set; }
        /// <summary>
        /// Итоговая сумма за почтовый сбор
        /// </summary>
        [JsonProperty("ground")]
        public TarifJsonClass Ground { get; set; }
        /// <summary>
        /// Итоговая сумма за авиасбор
        /// </summary>
        [JsonProperty("avia")]
        public TarifJsonClass Avia { get; set; }
        /// <summary>
        /// Итоговая страховка за объявленную ценность
        /// </summary>
        [JsonProperty("cover")]
        public TarifJsonClass Cover { get; set; }
        /// <summary>
        /// Тариф за дополнительную услугу
        /// </summary>
        [JsonProperty("service")]
        public TarifJsonClass Service { get; set; }
        /// <summary>
        /// Контрольные сроки доставки
        /// </summary>
        [JsonProperty("delivery")]
        public DeliveryClass Delivery { get; set; }
        /// <summary>
        /// Итоговая сумма платы без НДС в копейках
        /// </summary>
        [JsonProperty("pay")]
        public int Pay { get; set; }
        /// <summary>
        /// Сумма НДС в копейках (в валюте расчета)
        /// </summary>
        [JsonProperty("nds")]
        public int Nds { get; set; }
        /// <summary>
        /// Итоговая сумма платы с НДС в копейках
        /// </summary>
        [JsonProperty("paynds")]
        public int Paynds { get; set; }
        /// <summary>
        /// Ставка НДС в процентах
        /// </summary>
        [JsonProperty("ndsrate")]
        public int Ndsrate { get; set; }
        /// <summary>
        /// Итоговая сумма при оплате почтовыми марками в копейках (всегда кратна рублю)
        /// </summary>
        [JsonProperty("paymark")]
        public int Paymark { get; set; }


        /// <summary>
        /// Категория отправлния в формате <see cref="MailCtg"/>
        /// </summary>
        [JsonIgnore]
        public MailCtg? MailCtgEnum
        {
            get
            {
                try
                {
                    return MailCtgCode.GetTypeMailCtgByCode();
                }
                catch
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// Тип отправлния в формате <see cref="MailTypes"/>
        /// </summary>
        [JsonIgnore]
        public MailTypes? MailTypesEnum 
        {
            get
            {
                try
                {
                   return MailTypeCode.GetTypeMailTypeByCode();
                }
                catch
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// Направление отправлния в формате <see cref="DirectCtg"/>
        /// </summary>
        [JsonIgnore]
        public DirectCtg? DirectCtgEnum
        {
            get
            {
                try
                {
                   return DirectCtgCode.GetTypeDirectByCode();
                }
                catch
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// Направление отправлния в формате <see cref="TransTypes"/>
        /// </summary>
        [JsonIgnore]
        public TransTypes? TransTypesEnum
        {
            get
            {
                try
                {
                   return TransTypeCode.GetTypeTransTypesNotByCode();
                }
                catch
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// Договор Если есть (если нет то null)
        /// </summary>
        [JsonIgnore]
        public DogovorQueryClass Dogovor
        {
            get
            {
                if(DogovorString is null)
                {
                    return null;
                }
                else
                {
                    var items = DogovorString.Split('-');
                    if (items.Length >= 3)
                    {
                        var dogNumber = "";

                        for (int i = 2; i < items.Length; ++i)
                        {
                            dogNumber += $"{items[i]}-";
                        }
                        dogNumber = dogNumber.Trim('-');
                        return new DogovorQueryClass
                        {
                            RegionId = int.Parse(items[0]),
                            Inn = items[1],
                            DogNumber = dogNumber
                        };
                    }
                    else
                        return null;
                }
            }
        }
    }

}
