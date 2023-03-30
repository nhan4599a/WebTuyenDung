using WebTuyenDung.ViewModels.HomePage;

namespace WebTuyenDung.ViewModels.RecruimentNews
{
    public class DetailRecruimentNewsViewModel : HomePageRecruimentNewsViewModel
    {
        public string Gender { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Requirements { get; set; } = default!;

        public string RelativeSkills { get; set; } = default!;

        public string Benefit { get; set; } = default!;

        public string Deadline { get; set; } = default!;

        public int NumberOfCandidates { get; set; }
    }
}
