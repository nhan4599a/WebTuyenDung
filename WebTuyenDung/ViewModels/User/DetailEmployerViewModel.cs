using WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.ViewModels.User
{
    public class DetailEmployerViewModel : BaseEmployerViewModel
    {
        public string Address { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Size { get; set; } = default!;
    }
}
