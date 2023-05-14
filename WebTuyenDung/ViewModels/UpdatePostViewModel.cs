using Microsoft.AspNetCore.Http;

namespace WebTuyenDung.ViewModels
{
    public class UpdatePostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public IFormFile? Image { get; set; }

        public string Content { get; set; } = default!;

        public string OldImage { get; set; } = default!;
    }
}
