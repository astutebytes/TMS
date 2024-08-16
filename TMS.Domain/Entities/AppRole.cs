using Microsoft.AspNetCore.Identity;

namespace TMS.Domain.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }

        public AppRole()
        {
            AppUserRoles = [];
        }
    }
}
