using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(PotentialCandidateCountEntityConfiguration))]
    public class PotentialCandidateCount : BaseEntity
    {
        public int CandidateId { get; set; }

        public JobPosition JobPosition { get; set; }

        public int Count { get; set; }

        public Candidate Candidate { get; set; } = default!;
    }
}
