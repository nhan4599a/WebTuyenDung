using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.Requests
{
    public class ApplyJobRequest
    {
        public IFormFile? CV { get; set; }

        public int? CVId { get; set; }
    }
}
