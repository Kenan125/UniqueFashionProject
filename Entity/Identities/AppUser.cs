using Entity.Entities;
using Entity.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Identities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public Gender Gender { get; set; }


        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
