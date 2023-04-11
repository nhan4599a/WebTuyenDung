using Mapster;
using WebTuyenDung.ViewModels.User;

namespace WebTuyenDung.ViewModels.Page
{
    public class DetailEmployerPageViewModel : DetailEmployerViewModel
    {
        public string? Website { get; set; }

        public string CoverImage { get; set; } = default!;

        public DetailEmployerPageViewModel(DetailEmployerPageViewModel source)
        {
            source.Adapt(this);
        }

        public DetailEmployerPageViewModel() { }
    }
}
