using TMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TMS.Persistence.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.FullName).IsRequired()
                .HasMaxLength(128);
            builder.Property(p => p.IsActive).HasDefaultValue(true);
        }
    }
}
