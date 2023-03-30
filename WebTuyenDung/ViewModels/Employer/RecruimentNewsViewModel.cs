namespace WebTuyenDung.ViewModels.Employer
{
    public class RecruimentNewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public int NumberOfCandidates { get; set; }

        public string CreatedAt { get; set; } = default!;

        public string Deadline { get; set; } = default!;

        public string Status { get; set; } = default!;
    }
}
