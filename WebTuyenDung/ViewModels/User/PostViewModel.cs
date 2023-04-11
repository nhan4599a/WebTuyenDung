using Mapster;
using WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.ViewModels.User
{
    public class PostViewModel : BasePostViewModel
    {
        public string Author { get; set; } = default!;

        public PostViewModel(PostViewModel source)
        {
            source.Adapt(this);
        }

        public PostViewModel() { }
    }
}
