using WebTuyenDung.Enums;
using System;
using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(RecruimentNewsEntityConfiguration))]
    public class RecruimentNews : BasePostEntity
    {
        public int EmployerId { get; set; }

        public string JobName { get; set; } = default!;

        public JobPosition Position { get; set; }
        
        public string? PositionDetail { get; set; }

        public Gender? EmployeeGender { get; set; }

        public int CityId { get; set; }

        public string WorkingAddress { get; set; } = default!;

        public string RelativeSkills { get; set; } = default!;

        public string JobDescription { get; set; } = default!;

        public string JobRequirements { get; set; } = default!;

        public JobType JobType { get; set; }

        public string Salary { get; set; } = default!;

        public DateOnly? Deadline { get; set; }

        public int NumberOfCandidates { get; set; }

        public Employer Employer { get; set; } = default!;

        public Locale City { get; set; } = default!;
    }
}
