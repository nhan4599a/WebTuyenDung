using Mapster;
using System;
using WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.ViewModels.Management
{
    public class MinimalRecruimentNewsViewModel : BaseRecruimentNewsViewModel
    {
        public int NumberOfCandidates { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateOnly? Deadline { get; set; }

        public int View { get; set; }

        public bool IsApproved { get; set; }

        public MinimalRecruimentNewsViewModel(MinimalRecruimentNewsViewModel source)
        {
            source.Adapt(this);
        }

        public MinimalRecruimentNewsViewModel() { }
    }
}
