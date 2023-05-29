using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class EmployerDebtEntityConfiguration : IEntityTypeConfiguration<EmployerDebt>
    {
        public void Configure(EntityTypeBuilder<EmployerDebt> builder)
        {
            builder.Ignore(e => e.Id).Ignore(e => e.IsDeleted).Ignore(e => e.CreatedAt);

            builder.HasKey(e => e.EmployerId);
        }
    }
}
