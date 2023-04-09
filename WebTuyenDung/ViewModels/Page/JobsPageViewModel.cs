using System.Collections.Generic;
using WebTuyenDung.ViewModels.Candidate;

namespace WebTuyenDung.ViewModels.Page
{
    public class JobsPageViewModel
    {
        public PaginationResult<RecruimentNewsViewModel> SearchResult { get; set; } = default!;

        public List<RecruimentNewsViewModel> TopRecruimentNews { get; set; } = default!;
    }
}