using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(JobApplicationEntityConfiguration))]
    public class JobApplication : BaseEntity
    {
        public int CVId { get; set; }

        public int CandidateId { get; set; }

        public int RecruimentNewsId { get; set; }

        public JobApplicationStatus Status { get; set; }

        public string CandidateName { get; set; } = default!;

        public string JobName { get; set; } = default!;

        public string? CandidateNote { get; set; }

        public RecruimentNews RecruimentNews { get; set; } = default!;

        public CurriculumVitae CV { get; set; } = default!;
    }
}
