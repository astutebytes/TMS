using TMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TMS.Persistence.Data
{
    public class DataContext(DbContextOptions options) : IdentityDbContext<AppUser, AppRole, int,
                                IdentityUserClaim<int>, AppUserRole,
                                IdentityUserLogin<int>,
                                IdentityRoleClaim<int>,
                                IdentityUserToken<int>>(options)
    {
        public DbSet<TMSEvent> Events { get; set; }
        public DbSet<TMSCategory> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
