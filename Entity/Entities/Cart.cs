using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Cart
    {
        public Guid UserId { get; set; }  // Foreign key to the user       
        public AppUser User { get; set; }  // Navigation property
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
