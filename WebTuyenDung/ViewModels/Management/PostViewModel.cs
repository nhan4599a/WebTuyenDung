using Mapster;

namespace WebTuyenDung.ViewModels.Management
{
    public class PostViewModel : MinimalPostViewModel
    {
        public string Author { get; set; } = default!;

        public PostViewModel(PostViewModel source)
        {
            source.Adapt(this);
        }

        public PostViewModel() { }
    }
}
