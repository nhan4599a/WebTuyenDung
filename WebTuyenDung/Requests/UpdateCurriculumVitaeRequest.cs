using Microsoft.AspNetCore.Http;
using WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.Requests
{
    public class UpdateCurriculumVitaeRequest
    {
        public IFormFile? CV { get; set; }

        public string? Name { get; set; }

        public string? Url { get; set; }

        public CurriculumVitaeDetailViewModel? Data { get; set; }
    }
}
