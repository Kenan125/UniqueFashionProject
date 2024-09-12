using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ProductDtos;

namespace Entity.Dtos
{
    public class CartItemDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductDto Product { get; set; }
    }
}
