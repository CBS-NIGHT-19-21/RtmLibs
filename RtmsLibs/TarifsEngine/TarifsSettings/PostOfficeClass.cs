using Newtonsoft.Json;
using RtmLib.TarifsEngine.TarifsEnums;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Почтовый объект по тарификатору
    /// </summary>
    public class PostOfficeClass
    {
        /// <summary>
        /// Почтовый индекс объекта. Обязательно
        /// </summary>
        [JsonProperty("index")]
        public long IndexOps { get; set; }
        /// <summary>
        /// Назначение объекта в расчете
        /// </summary>
        [JsonProperty("tp")]
        public TarificatorObjectType PostType { get; set; }
        /// <summary>
        /// Индекс вышестоящего объекта. Опционально
        /// </summary>
        [JsonProperty("parent")]
        public long ParentIndex { get; set; }
        /// <summary>
        /// Наименование объекта. Обязательно
        /// </summary>
        [JsonProperty("name")]
        public string NapePostOffice { get; set; }
        /// <summary>
        /// Тип объекта ПС по РТМ-55. Опционально
        /// </summary>
        [JsonProperty("type")]
        public long TypeOps { get; set; }
        /// <summary>
        /// Тип индекса по РТМ-55. Опционально
        /// </summary>
        [JsonProperty("typei")]
        public long TypeIndex { get; set; }
        /// <summary>
        /// Индекс филиала. Опционально
        /// </summary>
        [JsonProperty("root")]
        public long RootIndex { get; set; }
        /// <summary>
        /// Код региона по Конституции РФ. Обязательно
        /// </summary>
        [JsonProperty("regionid")]
        public long RegionCode { get; set; }
        /// <summary>
        /// Логистический код региона. Опционально
        /// </summary>
        [JsonProperty("regiono")]
        public long RegionLogicCode { get; set; }
        /// <summary>
        /// Код района. Опционально
        /// </summary>
        [JsonProperty("areaid")]
        public long AreacCode { get; set; }
        /// <summary>
        /// Логистический код района. Опционально
        /// </summary>
        [JsonProperty("areao")]
        public long AreacLogicCode { get; set; }
        /// <summary>
        /// Код населенного пункта. Опционально
        /// </summary>
        [JsonProperty("placeid")]
        public long PalceCode { get; set; }
        /// <summary>
        /// Логистический код населенного пункта. Опционально
        /// </summary>
        [JsonProperty("placeo")]
        public long PalceLogicCode { get; set; }
        /// <summary>
        /// Признак нахождения объекта в региональном центре. Опционально
        /// </summary>
        [JsonProperty("region-main")]
        public long RegionCenter { get; set; }
        /// <summary>
        /// Признак нахождения объекта в районном центре. Опционально
        /// </summary>
        [JsonProperty("area-main")]
        public long AreaCenter { get; set; }
        /// <summary>
        /// Cut-off объекта в формате HHNNSS, где HH – часы, NN – минуты, SS – секунды.
        /// </summary>
        [JsonProperty("cutoff")]
        public long CutOff { get; set; }
        /// <summary>
        /// Признак «Труднодоступный» (опционально)
        /// </summary>
        [JsonProperty("hard")]
        public TarifsHard HardProperty { get; set; }
        /// <summary>
        /// Признак наличия ограничений по наземной пересылке на дату расчета
        /// </summary>
        [JsonProperty("combo")]
        public ComboEnum ComboProperty { get; set; }
        /// <summary>
        /// Признак наличия ограничения по доставке на дату расчета (опционально)
        /// </summary>
        [JsonProperty("closed")]
        public  ClosedPostOffice ClosedProperty { get; set; }
        /// <summary>
        /// Признак «Возможность примерки»
        /// </summary>
        [JsonProperty("item-checkmen")]
        public ItemCheck ItemCheckProperty { get; set; }
        /// <summary>
        /// Признак «Возможность проверки вложений»
        /// </summary>
        [JsonProperty("item-checkview")]
        public ItemCheckView ItemCheckViewProperty { get; set; }
        /// <summary>
        /// Признак «Частичная выдача»
        /// </summary>
        [JsonProperty("item-out-path")]
        public PartOut PartOutProperty { get; set; }
        /// <summary>
        /// Признак «Проверка работоспособности»
        /// </summary>
        [JsonProperty("item-checkwork")]
        public CheckWork CheckWorkProperty { get; set; }
        /// <summary>
        /// Признак «Является доставочным»
        /// </summary>
        [JsonProperty("move")]
        public IsMoveble IsMovebleProperty { get; set; }
        /// <summary>
        /// Максимально возможный поддерживаемый размер упаковки
        /// </summary>
        [JsonProperty("pack-max")]
        public PackegeEnum PackegeEnumProperty { get; set; }
        /// <summary>
        /// Признак «Оплата картой»
        /// </summary>
        [JsonProperty("pay-card")]
        public IsCardPay IsCardPayProperty { get; set; }
        /// <summary>
        /// Признак «Оплата наличными»
        /// </summary>
        [JsonProperty("pay-money")]
        public IsCash IsCashProperty { get; set; }
        /// <summary>
        /// Список кодов обслуживающих авиаузлов
        /// </summary>
        [JsonProperty("aviaport")]
        public long[] Aviaports { get; set; }
        /// <summary>
        /// Признак «Партнерский»
        /// </summary>
        [JsonProperty("partner")]
        public IsPartner IsPartnerProperty { get; set; }
        /// <summary>
        /// Максимальный вес
        /// </summary>
        [JsonProperty("weight-max")]
        public long MaxWeight { get; set; }
        /// <summary>
        /// Признак «Пункт выдачи заказов»
        /// </summary>
        [JsonProperty("pvz")]
        public IsPvz IsPvzProperty { get; set; }
    }
}