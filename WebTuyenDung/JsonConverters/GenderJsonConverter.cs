using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebTuyenDung.Enums;

namespace WebTuyenDung.JsonConverters
{
    public class GenderJsonConverter : JsonConverter<Gender>
    {
        public override Gender Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (Gender)reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, Gender value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value);
        }
    }
}
