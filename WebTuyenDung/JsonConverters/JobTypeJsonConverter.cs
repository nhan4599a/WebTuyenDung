using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebTuyenDung.Enums;

namespace WebTuyenDung.JsonConverters
{
    public class JobTypeJsonConverter : JsonConverter<JobType>
    {
        public override JobType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (JobType)reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, JobType value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value);
        }
    }
}
