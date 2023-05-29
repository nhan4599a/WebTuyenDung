using System.Collections.Generic;
using WebTuyenDung.ViewModels.Statistic;

namespace WebTuyenDung.ViewModels.Employer
{
    public class StatisticViewModel
    {
        public int ApprovedRecruimentNews { get; set; }

        public int WaitingForApproveRecruimentNews { get; set; }

        public int ApprovedPosts { get; set; }

        public int TotalCandidates { get; set; }

        public List<BaseRecruimentNewsViewModel> TopViewRecruimentNews { get; set; } = default!;

        public Dictionary<int, int> ApplicationsCountChartData { get; set; } = default!;

        public int Balance { get; set; }
    }
}
