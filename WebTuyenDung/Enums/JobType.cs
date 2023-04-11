using System;

namespace WebTuyenDung.Enums
{
    public enum JobType : byte
    {
        PartTime,
        FullTime,
        Remote
    }

    public static class JobTypeRepresentation
    {
        public static string GetRepresentation(this JobType jobType)
        {
            return jobType switch
            {
                JobType.FullTime => "Toàn thời gian",
                JobType.PartTime => "Bán thời gian",
                JobType.Remote => "Làm việc remote từ xa",
                _ => throw new NotImplementedException()
            };
        }
    }
}
