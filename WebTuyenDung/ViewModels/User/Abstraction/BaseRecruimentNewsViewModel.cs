using WebTuyenDung.ViewModels.Abstraction;
using RootAbstraction = WebTuyenDung.ViewModels.Abstraction;

namespace WebTuyenDung.ViewModels.User.Abstraction
{
    public class BaseRecruimentNewsViewModel : RootAbstraction.BaseRecruimentNewsViewModel
    {
        public string Salary { get; set; } = default!;

        public int? MinimumSalary { get; set; }

        public int? MaximumSalary { get; set; }

        public BaseEmployerViewModel Employer { get; set; } = default!;
    }
}