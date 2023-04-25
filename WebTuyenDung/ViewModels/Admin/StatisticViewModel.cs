using System.Collections.Generic;
using WebTuyenDung.ViewModels.Statistic;

namespace WebTuyenDung.ViewModels.Admin
{
    public class StatisticViewModel
    {
        public int NumberOfCandidates { get; set; }

        public int NumberOfEmployers { get; set; }

        public int NumberOfRecruimentNews { get; set; }

        public int NumberOfPosts { get; set; }

        public Dictionary<int, int> JobFoundCandidatesDataChart { get; set; } = default!;

        public List<RecruimentNewsViewModel> TopViewRecruimentNews { get; set; } = default!;
    }
}
