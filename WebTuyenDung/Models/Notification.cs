using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(NotificationEntityConfiguration))]
    public class Notification : BaseEntity
    {
        public int CandidateId { get; set; }

        public string Message { get; set; } = default!;

        public int RecruimentNewsId { get; set; }
    }
}
