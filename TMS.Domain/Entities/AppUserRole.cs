using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TMS.Domain.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public required AppUser User { get; set; }
        public required AppRole Role { get; set; }
    }
}
