using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.Requests
{
    public class ApplyJobRequest
    {
        public bool IsCurriculumVitaeUploaded { get; set; }

        public IFormFile? CurriculumVitae { get; set; }

        public int? CurriculumVitaeId { get; set; }
    }
}
