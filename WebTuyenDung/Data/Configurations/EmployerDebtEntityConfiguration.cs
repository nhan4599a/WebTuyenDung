using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class EmployerDebtEntityConfiguration : BaseEntityConfiguration<EmployerDebt>
    {
        public override void Configure(EntityTypeBuilder<EmployerDebt> builder)
        {
            base.Configure(builder);

            builder.Ignore(e => e.Id).Ignore(e => e.IsDeleted).Ignore(e => e.CreatedAt);

            builder.HasKey(e => e.EmployerId);
        }
    }
}
