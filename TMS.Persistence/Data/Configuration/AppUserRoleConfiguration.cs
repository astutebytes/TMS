using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.Domain.Entities;

namespace TMS.Persistence.Data.Configuration
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("AppUserRoles");

            builder.HasKey(urKey => new { urKey.UserId, urKey.RoleId });

            builder
                .HasOne(fk => fk.User)
                .WithMany(fk => fk.AppUserRoles)
                .HasForeignKey(fk => fk.UserId)
                .IsRequired();
            builder
                .HasOne(fk => fk.Role)
                .WithMany(fk => fk.AppUserRoles)
                .HasForeignKey(fk => fk.RoleId)
                .IsRequired();
        }
    }
}
