using Mapster;
using System;

namespace WebTuyenDung.ViewModels.User
{
    public class DetailRecruimentNewsViewModel : StandardRecruimentNewsViewModel
    {
        public DateTimeOffset CreatedAt { get; set; }

        public DateOnly? Deadline { get; set; }

        public bool IsSaved { get; set; }

        public DetailRecruimentNewsViewModel(DetailRecruimentNewsViewModel source)
        {
            source.Adapt(this);
        }

        public DetailRecruimentNewsViewModel() { }
    }
}
