using Newtonsoft.Json;

namespace RtmLib.TarifsEngine.TarifsSettings
{
    /// <summary>
    /// Класс услуг по тарификатору (По запросу)
    /// </summary>
    public class ServiseTarifClass
    {
        /// <summary>
        /// Код услуги
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Наименование услуги
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Код отметки по РТМ-2
        /// </summary>
        [JsonProperty("mark")]
        public int Mark { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}