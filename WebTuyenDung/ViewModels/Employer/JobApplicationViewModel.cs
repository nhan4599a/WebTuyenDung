using WebTuyenDung.Models;

namespace WebTuyenDung.ViewModels.Employer
{
    public class JobApplicationViewModel
    {
        public int Id { get; set; }

        public int RecruimentNewsId { get; set; }

        public string JobTitle { get; set; } = default!;

        public string CandidateName { get; set; } = default!;

        public int CVId { get; set; }

        public string CreatedAt { get; set; } = default!;

        public string Status { get; set; } = default!;
    }
}
