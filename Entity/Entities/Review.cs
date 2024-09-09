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
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string UserReview { get; set; }

        public virtual Product Product { get; set; }
        public virtual AppUser User { get; set; }
    }
}
