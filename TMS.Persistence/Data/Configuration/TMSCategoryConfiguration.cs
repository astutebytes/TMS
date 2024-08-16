using TMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TMS.Persistence.Data.Configuration
{
    public class TMSCategoryConfiguration : IEntityTypeConfiguration<TMSCategory>
    {
        public void Configure(EntityTypeBuilder<TMSCategory> builder)
        {
            builder.ToTable("TMSCategories");

            builder.Property(p => p.Name).HasMaxLength(64);
        }
    }
}
