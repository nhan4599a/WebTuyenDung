using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(EmployerDebtEntityConfiguration))]
    public class EmployerDebt : BaseEntity
    {
        public int EmployerId { get; set; }

        public int Balance { get; set; }
    }
}
