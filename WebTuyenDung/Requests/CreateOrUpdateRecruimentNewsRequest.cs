using System;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Requests
{
    public class CreateOrUpdateRecruimentNewsRequest
    {
        public string JobName { get; set; } = default!;

        public JobPosition Position { get; set; }

        public string? PositionDetail { get; set; }

        public JobType JobType { get; set; }

        public string Salary { get; set; } = default!;

        public int? MinimumSalary { get; set; }

        public int? MaximumSalary { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public int WardId { get; set; }

        public string WorkingAddress { get; set; } = default!;

        public string JobDescription { get; set; } = default!;

        public string JobRequirements { get; set; } = default!;

        public string RelativeSkills { get; set; } = default!;

        public string Benefit { get; set; } = default!;

        public int NumberOfCandidates { get; set; } = default!;

        public Gender? Gender { get; set; }

        public DateOnly? Deadline { get; set; }
    }
}
