using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DJLNET.WebCore.WebApi
{
    /// <summary>
    /// 在需要的响应属性上加上 [JsonConverter(typeof(CustomDateConverter))] 或  [JsonConverter(typeof(CustomDateConverter),"yyyy年MM月dd日")] 即可
    /// </summary>
    public class CustomDateConverter : DateTimeConverterBase
    {
        private IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { };
        public CustomDateConverter(string format)
        {
            dtConverter.DateTimeFormat = format;
        }

        public CustomDateConverter() : this("yyyy-MM-dd") { }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return dtConverter.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            dtConverter.WriteJson(writer, value, serializer);
        }
    }
}
