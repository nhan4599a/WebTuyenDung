using WebTuyenDung.Enums;
using System;

namespace WebTuyenDung.Models
{
    public class RecruimentNews : BasePostEntity
    {
        public int EmployerId { get; set; }

        public string JobName { get; set; } = default!;

        public Gender? EmployeeGender { get; set; }

        public string WorkingAddress { get; set; } = default!;

        public string RelativeSkills { get; set; } = default!;

        public string JobDescription { get; set; } = default!;

        public string JobRequirements { get; set; } = default!;

        public JobType JobType { get; set; }

        public string Salary { get; set; } = default!;

        public DateOnly Deadline { get; set; }

        public int NumberOfCandidates { get; set; }

        public Employer Employer { get; set; } = default!;
    }
}
