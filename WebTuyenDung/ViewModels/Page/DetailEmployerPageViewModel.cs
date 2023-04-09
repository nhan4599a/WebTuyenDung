using Mapster;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebTuyenDung.ViewModels.Candidate;

namespace WebTuyenDung.ViewModels.Page
{
    public class DetailEmployerPageViewModel : DetailEmployerViewModel
    {
        public List<RecruimentNewsViewModel> RecruimentNews { get; set; } = default!;

        public class RecruimentNewsViewModel : BaseRecruimentNewsViewModel
        {
            public DateOnly? Deadline { get; set; }
        }

        public DetailEmployerPageViewModel(DetailEmployerPageViewModel source)
        {
            source.Adapt(this);
        }

        public DetailEmployerPageViewModel() { }
    }
}
