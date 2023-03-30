using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.ViewModels
{
    public class CreatePostViewModel
    {
        public string Title { get; set; } = default!;

        public IFormFile Image { get; set; } = default!;

        public string Content { get; set; } = default!;
    }
}
