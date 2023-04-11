using Mapster;
using WebTuyenDung.Enums;

namespace WebTuyenDung.ViewModels.User
{
    public class StandardRecruimentNewsViewModel : Abstraction.BaseRecruimentNewsViewModel
    {
        public JobType JobType { get; set; } = default!;

        public string WorkingSite { get; set; } = default!;

        public StandardRecruimentNewsViewModel(StandardRecruimentNewsViewModel source)
        {
            source.Adapt(this);
        }

        public StandardRecruimentNewsViewModel() { }
    }
}
