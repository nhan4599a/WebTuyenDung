using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(LikedCurriculumVitaeEntityConfiguration))]
    public class LikedCurriculumVitae : BaseEntity
    {
        public int EmployerId { get; set; }

        public int CVId { get; set; }
    }
}
