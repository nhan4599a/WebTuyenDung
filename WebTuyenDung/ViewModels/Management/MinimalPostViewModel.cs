using Mapster;
using System;
using WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.ViewModels.Management
{
    public class MinimalPostViewModel : BasePostViewModel
    {
        public DateTimeOffset CreatedAt { get; set; }

        public int View { get; set; }

        public MinimalPostViewModel(MinimalPostViewModel source)
        {
            source.Adapt(this);
        }

        public MinimalPostViewModel() { }
    }
}
