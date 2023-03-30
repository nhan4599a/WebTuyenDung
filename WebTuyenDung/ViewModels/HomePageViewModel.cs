using System.Collections.Generic;
using WebTuyenDung.ViewModels.HomePage;

namespace WebTuyenDung.ViewModels
{
    public class HomePageViewModel
    {
        public List<HomePageRecruimentNewsViewModel> TopRecruimentNews { get; set; } = default!;

        public List<PostViewModel> TopPosts { get; set; } = default!;
    }
}
