using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.CheckSpi.CheckSpiEntr.Specials
{
    public class SpecialDateTimeConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var item = (long)reader.Value;
            var dateTimeFromJavaScript = new DateTime(1970, 01, 01).AddMilliseconds(item);
            return dateTimeFromJavaScript;
            //throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("dd-MM-yyyy hh:mm:ss"));
        }
    }
}
