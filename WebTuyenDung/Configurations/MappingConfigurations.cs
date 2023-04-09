using Mapster;
using WebTuyenDung.Models;
using WebTuyenDung.ViewModels.Candidate;

namespace WebTuyenDung.Configurations
{
    public static class MappingConfigurations
    {
        public static void ConfigMappings()
        {
            TypeAdapterConfig<RecruimentNews, BaseRecruimentNewsViewModel>
                .NewConfig()
                .Map(
                    dest => dest.WorkingSite,
                    source => source.City.Name.StartsWith("Tỉnh") ? source.City.Name.Substring(5) : source.City.Name.Substring(10));
        }
    }
}
