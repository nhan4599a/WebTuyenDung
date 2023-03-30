namespace WebTuyenDung.ViewModels.Admin
{
    public class RecruimentNewsViewModel
    {
        public int Id { get; set; }

        public string JobName { get; set; } = default!;

        public string EmployerName { get; set; } = default!;

        public int NumberOfCandidates { get; set; }

        public string CreatedAt { get; set; } = default!;

        public string Deadline { get; set;} = default!;

        public int View { get; set; }

        public string Status { get; set; } = default!;
    }
}
