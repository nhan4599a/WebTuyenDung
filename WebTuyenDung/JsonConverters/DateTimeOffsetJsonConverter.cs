using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebTuyenDung.Constants;

namespace WebTuyenDung.JsonConverters
{
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString()!;
            return DateTimeOffset.ParseExact(value, DateTimeFormatConstants.FULL_DATE_TIME_FORMAT, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateTimeFormatConstants.FULL_DATE_TIME_FORMAT));
        }
    }
}
