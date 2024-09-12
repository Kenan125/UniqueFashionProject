using Entity.Entities;
using Entity.Enums;
using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ProductDtos
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
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string SizeName { get; set; }
        public string Color { get; set; }
        public string PrimaryImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public string SellerName { get; set; }

        //public virtual SizeDto Size { get; set; }
        //public virtual BrandDto Brand { get; set; }
        //public virtual SellerDto Seller { get; set; }
        //public virtual CategoryDto Category { get; set; }
        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
