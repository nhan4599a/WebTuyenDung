using WebTuyenDung.Enums;

namespace WebTuyenDung.ViewModels.User
{
    public class FullDetailRecruimentNewsViewModel : DetailRecruimentNewsViewModel
    {
        public string JobDescription { get; set; } = default!;

        public string JobRequirements { get; set;} = default!;

        public string RelativeSkills { get; set; } = default!;

        public string Benefit { get; set; } = default!;

        public string WorkingAddress { get; set; } = default!;

        public int NumberOfCandidates { get; set; }

        public Gender? Gender { get; set; }

        public new DetailEmployerViewModel Employer { get; set; } = default!;
    }
}
