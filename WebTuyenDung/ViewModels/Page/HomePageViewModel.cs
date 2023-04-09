using System.Collections.Generic;
using WebTuyenDung.ViewModels.Candidate;

namespace WebTuyenDung.ViewModels.Page
{
    public class HomePageViewModel
    {
        public List<MinimalRecruimentNewsViewModel> TopRecruimentNews { get; set; } = default!;

        public List<PostViewModel> TopPosts { get; set; } = default!;
    }
}
