using Mapster;
using System;

namespace WebTuyenDung.ViewModels.User
{
    public class FullDetailPostViewModel : PostViewModel
    {
        public string Content { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; }

        public int View { get; set; }

        public FullDetailPostViewModel(FullDetailPostViewModel source)
        {
            source.Adapt(this);
        }

        public FullDetailPostViewModel() { }
    }
}
