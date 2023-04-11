using Mapster;
using System.Reflection;
using WebTuyenDung.Models;
using WebTuyenDung.ViewModels.Management;
using User = WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.Configurations
{
    public static class MappingConfigurations
    {
        public static void ConfigMappings()
        {
            TypeAdapterConfig<RecruimentNews, User.StandardRecruimentNewsViewModel>
                .NewConfig()
                .Include<RecruimentNews, User.StandardRecruimentNewsViewModel>()
                .Include<RecruimentNews, User.DetailRecruimentNewsViewModel>()
                .Map(
                    dest => dest.WorkingSite,
                    source => source.City.Name.StartsWith("Tỉnh") ? source.City.Name.Substring(5) : source.City.Name.Substring(10));

            TypeAdapterConfig<Post, PostViewModel>
                .NewConfig()
                .Map(
                    dest => dest.Author,
                    source => source.Author.Name);

            TypeAdapterConfig<Post, User.PostViewModel>
                .NewConfig()
                .Map(
                    dest => dest.Author,
                    source => source.Author.Name);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
