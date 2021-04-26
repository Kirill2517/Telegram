using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramLib.Share.Utils.Extensions
{
    public class FlagConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int outVal = 0;
            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    outVal += (int)Enum.Parse(objectType, reader.Value.ToString());
                    reader.Read();
                }
            }
            return outVal;
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            var flags = value.ToString()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(f => $"\"{f}\"");

            writer.WriteRawValue($"[{string.Join(", ", flags)}]");
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
