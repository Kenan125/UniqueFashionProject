using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class OrderDetailDto : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool IsRefunded { get; set; }

        public virtual OrderDto Order { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}
