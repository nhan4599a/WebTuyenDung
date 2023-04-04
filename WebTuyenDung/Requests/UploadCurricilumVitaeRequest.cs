using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.Requests
{
    public class UploadCurricilumVitaeRequest
    {
        public string Name { get; set; } = default!;

        public IFormFile CV { get; set; } = default!;
    }
}
