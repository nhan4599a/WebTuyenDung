using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebTuyenDung.Constants;

namespace WebTuyenDung.JsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString()!;
            return DateOnly.ParseExact(value, DateTimeFormatConstants.DATE_ONLY_FORMAT);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateTimeFormatConstants.DATE_ONLY_FORMAT));
        }
    }
}
