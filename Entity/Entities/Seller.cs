using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Seller : BaseEntity
    {
        public string Name { get; set; }
        public int? UserId { get; set; }

        public AppUser User { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
