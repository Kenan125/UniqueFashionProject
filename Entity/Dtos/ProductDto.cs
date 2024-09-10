using Entity.Enums;
using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Condition { get; set; }
        public Gender Gender { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public Guid CategoryId { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string PrimaryImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public Guid SellerId { get; set; }


        public virtual UserDto Seller { get; set; }
        public virtual CategoryDto Category { get; set; }
    }
}
