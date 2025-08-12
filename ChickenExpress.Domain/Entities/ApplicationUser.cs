using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChickenExpress.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
    }
}
