using System;

namespace WebTuyenDung.Enums
{
    public enum JobApplicationStatus
    {
        Received,
        Seen,
        Potential,
        Scheduled,
        Passed,
        Rejected
    }

    public static class JobApplicationStatusRepresentation
    {
        public static string GetRepresentation(this JobApplicationStatus status)
        {
            return status switch
            {
                JobApplicationStatus.Received => "Đã nhận",
                JobApplicationStatus.Seen => "Đã xem",
                JobApplicationStatus.Potential => "Ứng viên tiềm năng",
                JobApplicationStatus.Scheduled => "Đã hẹn phỏng vấn",
                JobApplicationStatus.Passed => "Đã đậu phỏng vấn",
                JobApplicationStatus.Rejected => "Đã trượt",
                _ => throw new NotImplementedException()
            };
        }
    }
}
