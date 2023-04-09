using Mapster;
using System;

namespace WebTuyenDung.ViewModels.Candidate
{
    public class DetailRecruimentNewsViewModel : BaseRecruimentNewsViewModel
    {
        public string Gender { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Requirements { get; set; } = default!;

        public string RelativeSkills { get; set; } = default!;

        public string Benefit { get; set; } = default!;

        public DateOnly? Deadline { get; set; } = default!;

        public int NumberOfCandidates { get; set; }

        public DetailEmployerViewModel Employer { get; set; } = default!;

        public DetailRecruimentNewsViewModel(DetailRecruimentNewsViewModel source)
        {
            source.Adapt(this);
        }

        public DetailRecruimentNewsViewModel() { }
    }
}
