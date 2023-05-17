using Mapster;
using System.Reflection;
using WebTuyenDung.Enums;
using WebTuyenDung.Helper;
using WebTuyenDung.Models;
using WebTuyenDung.Requests;
using WebTuyenDung.ViewModels;
using WebTuyenDung.ViewModels.Employer;
using WebTuyenDung.ViewModels.User;
using Management = WebTuyenDung.ViewModels.Management;

namespace WebTuyenDung.Configurations
{
    public static class MappingConfigurations
    {
        public static void ConfigMappings()
        {
            TypeAdapterConfig<RecruimentNews, StandardRecruimentNewsViewModel>
                .NewConfig()
                .Include<RecruimentNews, StandardRecruimentNewsViewModel>()
                .Include<RecruimentNews, DetailRecruimentNewsViewModel>()
                .Include<RecruimentNews, FullDetailRecruimentNewsViewModel>()
                .Map(
                    dest => dest.WorkingSite,
                    source => source.City.Name.StartsWith("Tỉnh") ? source.City.Name.Substring(5) : source.City.Name.Substring(10));

            TypeAdapterConfig<Post, Management.PostViewModel>
                .NewConfig()
                .Map(
                    dest => dest.Author,
                    source => source.Author.Name);

            TypeAdapterConfig<Post, PostViewModel>
                .NewConfig()
                .Include<Post, FullDetailPostViewModel>()
                .Map(
                    dest => dest.Author,
                    source => source.Author.Name);

            TypeAdapterConfig<CurriculumVitae, CurriculumVitaeViewModel>
                .NewConfig()
                .Map(dest => dest.Url, source => source.Type == CVType.DirectInput ? null : source.FilePath);

            TypeAdapterConfig<JobApplication, JobApplicationHistoryViewModel>
                .NewConfig()
                .Map(e => e.EmployerAvatar, source => source.RecruimentNews.Employer.Avatar)
                .Map(e => e.EmployerName, source => source.RecruimentNews.Employer.Name);

            TypeAdapterConfig<JobApplication, JobApplicationViewModel>
                .NewConfig()
                .Map(e => e.LikeCount, e => e.CV.LikeCount);

            TypeAdapterConfig<BaseSignUpRequest, User>
                .NewConfig()
                .Include<CandidateSignUpRequest, Candidate>()
                .Include<SignUpEmployerRequest, Employer>()
                .Map(e => e.PasswordHashed, source => source.Password.Sha256());

            TypeAdapterConfig<CurriculumVitae, CurriculumVitaeDetailViewModel>
                .NewConfig()
                .Map(e => e.Image, source => source.FilePath)
                .Map(e => e.Introduction, source => source.Detail!.Introduction)
                .Map(e => e.ExpectedPosition, source => source.Detail!.ExpectedPosition)
                .Map(e => e.Email, source => source.Detail!.Email)
                .Map(e => e.PhoneNumber, source => source.Detail!.PhoneNumber)
                .Map(e => e.BirthDay, source => source.Detail!.BirthDay)
                .Map(e => e.Gender, source => source.Detail!.Gender)
                .Map(e => e.Address, source => source.Detail!.Address)
                .Map(e => e.SourceVersionControlUrl, source => source.Detail!.SourceVersionControlUrl)
                .Map(e => e.Objective, source => source.Detail!.Objective)
                .Map(e => e.Experience, source => source.Detail!.Experience)
                .Map(e => e.Skills, source => source.Detail!.Skills)
                .Map(e => e.Education, source => source.Detail!.Education)
                .Map(e => e.SoftSkills, source => source.Detail!.SoftSkills);

            TypeAdapterConfig<CreateCVViewModel, CurriculumVitaeDetail>
                .NewConfig()
                .Map(e => e.Skills, source => source.Skills.Substring(4, source.Skills.Length - 9))
                .Map(e => e.SoftSkills, source => source.SoftSkills.Substring(4, source.SoftSkills.Length - 9));

            TypeAdapterConfig<Candidate, PotentialCandidateViewModel>
                .NewConfig()
                .Map(e => e.Email, source => source.Username);

			TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
