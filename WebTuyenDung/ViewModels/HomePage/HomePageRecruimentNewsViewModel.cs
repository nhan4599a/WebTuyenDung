namespace WebTuyenDung.ViewModels.HomePage
{
    public class HomePageRecruimentNewsViewModel
    {
        public int Id { get; set; }

        public string JobTitle { get; set; } = default!;

        public EmployerViewModel Employer { get; set; } = default!;

        public string SalaryRange { get; set; } = default!;

        public string JobType { get; set; } = default!;
    }
}
