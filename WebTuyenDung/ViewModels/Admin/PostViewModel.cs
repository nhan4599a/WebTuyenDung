namespace WebTuyenDung.ViewModels.Admin
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Image { get; set; } = default!;

        public string Title { get; set; } = default!;

        public string Author { get; set; } = default!;

        public string CreatedAt { get; set; } = default!;

        public int View { get; set; }

        public string Status { get; set; } = default!;
    }
}
