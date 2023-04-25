using WebTuyenDung.Enums;

namespace WebTuyenDung.Requests
{
    public class SaveRecruimentNewsRequest
    {
        public int? EmployerId { get; set; }

        public string? EmployerName { get; set; }

        public string? EmployerAvatar { get; set; }

        public string? JobName { get; set; }

        public string? Salary { get; set; }

        public JobType? JobType { get; set; }

        public string? WorkingSite { get; set; }

        public bool IsSaveAction { get; set; }
    }
}
