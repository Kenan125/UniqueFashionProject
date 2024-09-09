using Entity.Entities;
using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class OrderDto : BaseDto
    {
        public Guid UserId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDiscountApplied { get; set; }
        public bool IsFullyrefunded { get; set; } = false;
        public virtual List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
        public virtual UserDto User { get; set; }
    }
}
