using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.Requests
{
    public class ReplaceCurriculumVitaeRequest
    {
        public IFormFile? CV { get; set; }

        public string Name { get; set; } = default!;

        public string Url { get; set; } = default!;
    }
}
