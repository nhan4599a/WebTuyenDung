using System.Collections.Generic;

namespace WebTuyenDung.ViewModels.Page
{
    public class HomePageViewModel
    {
        public List<User.StandardRecruimentNewsViewModel> TopRecruimentNews { get; set; } = default!;

        public List<User.PostViewModel> TopPosts { get; set; } = default!;
    }
}
