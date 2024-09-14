using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Review : BaseEntity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int SellerId { get; set; }   // The seller being reviewed
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual Product Product { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Seller Seller { get; set; } // The seller being reviewed
    }
}
