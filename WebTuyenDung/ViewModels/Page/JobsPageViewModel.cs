using System.Collections.Generic;
using WebTuyenDung.ViewModels.Abstraction;
using WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.ViewModels.Page
{
    public class JobsPageViewModel
    {
        public IPaginationResult<DetailRecruimentNewsViewModel> SearchResult { get; set; } = default!;

        public List<TopJobsViewModel> TopRecruimentNews { get; set; } = default!;
    }
}