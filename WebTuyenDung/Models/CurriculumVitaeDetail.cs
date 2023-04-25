using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(CurriculumVitaeDetailEntityConfiguration))]
    public class CurriculumVitaeDetail : BaseEntity
    {
        public int CVId { get; set; }

        public string ExpectedPosition { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string? SourceVersionControlUrl { get; set; }

        public string Objective { get; set; } = default!;

        public string Experience { get; set; } = default!;

        public string Skills { get; set; } = default!;

        public string Education { get; set; } = default!;

        public string SoftSkills { get; set; } = default!;

        public string? Rewards { get; set; }
    }
}
