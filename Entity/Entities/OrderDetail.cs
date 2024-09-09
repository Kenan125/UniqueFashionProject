using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool IsRefunded { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
