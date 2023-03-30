using System.Text.Json;

namespace WebTuyenDung.JsonConverters
{
    public class ApplicationWideJsonConverter
    {
        public static readonly JsonSerializerOptions DefaultSerializerOptions = new();

        static ApplicationWideJsonConverter()
        {
            DefaultSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            DefaultSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        }
    }
}
