using Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Entity.Identities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int GenderId { get; set; }

        public virtual Gender Gender { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

    }
}
