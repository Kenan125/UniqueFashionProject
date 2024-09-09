using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDiscountApplied { get; set; }
        public bool IsFullyrefunded { get; set; } = false;
        public virtual List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual AppUser User { get; set; }

    }
}
