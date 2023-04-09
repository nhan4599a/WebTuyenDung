using Mapster;

namespace WebTuyenDung.ViewModels.Candidate
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Image { get; set; } = default!;

        public string Title { get; set; } = default!;

        public string PostedBy { get; set; } = default!;

        public PostViewModel(PostViewModel source)
        {
            source.Adapt(this);
        }

        public PostViewModel() { }
    }
}
