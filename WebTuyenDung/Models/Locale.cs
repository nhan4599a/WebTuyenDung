using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(LocaleEntityConfiguration))]
    public class Locale : BaseEntity
    {
        public string Name { get; set; } = default!;

        public int? Parent { get; set; }
    }
}
