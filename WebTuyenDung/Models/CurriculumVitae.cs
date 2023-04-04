using Microsoft.EntityFrameworkCore;
using System;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(CurriculumVitaeEntityConfiguration))]
    public class CurriculumVitae : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string FilePath { get; set; } = default!;

        public int CandidateId { get; set; }

        public DateTimeOffset LastModifiedDate { get; set; }
    }
}
