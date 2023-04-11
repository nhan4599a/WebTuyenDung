using Mapster;

namespace WebTuyenDung.ViewModels.Abstraction
{
    public class BaseEmployerViewModel : BaseViewModel
    {
        public string Name { get; set; } = default!;

        public string Avatar { get; set; } = default!;

        public BaseEmployerViewModel(BaseEmployerViewModel source)
        {
            source.Adapt(this);
        }

        public BaseEmployerViewModel() { }
    }
}
