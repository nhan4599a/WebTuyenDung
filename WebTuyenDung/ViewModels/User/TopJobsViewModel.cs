using Mapster;
using System;

namespace WebTuyenDung.ViewModels.User
{
    public class TopJobsViewModel : Abstraction.BaseRecruimentNewsViewModel
    {
        public DateOnly? Deadline { get; set; }

        public TopJobsViewModel(TopJobsViewModel source)
        {
            source.Adapt(this);
        }

        public TopJobsViewModel() { }
    }
}
