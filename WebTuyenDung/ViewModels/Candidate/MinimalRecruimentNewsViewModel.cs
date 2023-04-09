using Mapster;

namespace WebTuyenDung.ViewModels.Candidate
{
    public class MinimalRecruimentNewsViewModel : BaseRecruimentNewsViewModel
    {
        public MinimalEmployerViewModel Employer { get; set; } = default!;

        public MinimalRecruimentNewsViewModel(MinimalRecruimentNewsViewModel source)
        {
            source.Adapt(this);
        }

        public MinimalRecruimentNewsViewModel() { }
    }
}
