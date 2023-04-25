using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(SavedRecruimentNewsEntityConfiguration))]
    public class SavedRecruimentNews
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public int RecruimentNewsId { get; set; }

        public int EmployerId { get; set; }

        public string EmployerName { get; set; } = default!;

        public string EmployerAvatar { get; set; } = default!;

        public string JobName { get; set; } = default!;

        public string Salary { get; set; } = default!;

        public JobType JobType { get; set; }

        public string WorkingSite { get; set; } = default!;
    }
}
