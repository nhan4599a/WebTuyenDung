using Mapster;
using System;

namespace WebTuyenDung.ViewModels.Candidate
{
    public class RecruimentNewsViewModel : BaseRecruimentNewsViewModel
    {
        public MinimalEmployerViewModel Employer { get; set; } = default!;

        public DateOnly? DeadLine { get; set; }

        public RecruimentNewsViewModel(RecruimentNewsViewModel source)
        {
            source.Adapt(this);
        }

        public RecruimentNewsViewModel() { }
    }
}
