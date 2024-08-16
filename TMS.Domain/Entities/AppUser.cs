using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace TMS.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public required string FullName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AppUserRole> AppUserRoles { get; set; }
        public ICollection<TMSEvent> TmsEvents { get; set; }

        public AppUser()
        {
            AppUserRoles = [];
            TmsEvents = [];
        }
    }
}
