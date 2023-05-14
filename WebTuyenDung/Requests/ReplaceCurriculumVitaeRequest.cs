using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.Requests
{
    public class ReplaceCurriculumVitaeRequest
    {
        public IFormFile CV { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Url { get; set; } = default!;
    }
}
