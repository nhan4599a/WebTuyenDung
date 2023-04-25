using Mapster;
using System;
using WebTuyenDung.Enums;

namespace WebTuyenDung.ViewModels.User
{
    public class JobApplicationHistoryViewModel
    {
        public string EmployerAvatar { get; set; } = default!;

        public string JobName { get; set; } = default!;

        public int RecruimentNewsId { get; set; }

        public int CVId { get; set; }

        public string EmployerName { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; }

        public JobApplicationStatus Status { get; set; }

        public JobApplicationHistoryViewModel(JobApplicationHistoryViewModel source)
        {
            source.Adapt(this);
        }

        public JobApplicationHistoryViewModel() { }
    }
}
