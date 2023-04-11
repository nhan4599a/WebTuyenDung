using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebTuyenDung.Enums;

namespace WebTuyenDung.JsonConverters
{
    public class UserRoleJsonConverter : JsonConverter<UserRole>
    {
        public override UserRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (UserRole)reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, UserRole value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value);
        }
    }
}
