using TMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TMS.Persistence.Data.Configuration
{
    public class TMSEventConfiguration : IEntityTypeConfiguration<TMSEvent>
    {
        public void Configure(EntityTypeBuilder<TMSEvent> builder)
        {
            builder.ToTable("TMSEvents");

            builder.HasOne(u => u.Category)
                    .WithMany(th => th.TMSEvents)
                    .HasForeignKey(fk => fk.CategoryId).IsRequired();

            builder.HasOne(u => u.AppUser)
                    .WithMany(ev => ev.TmsEvents)
                    .HasForeignKey(fk => fk.AppUserId).IsRequired();
        }
    }
}
