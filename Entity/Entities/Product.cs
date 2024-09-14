using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int? StockQuantity { get; set; }
        public string? Condition { get; set; }
        public int? GenderId { get; set; }
        public int? AgeGroupId { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? SizeId { get; set; }
        public string? Color { get; set; }
        public string? PrimaryImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; } = new List<string>();
        public int? SellerId { get; set; }

        public virtual Size Size { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Seller Seller { get; set; }     
        public virtual Category Category { get; set; }
        public virtual AgeGroup AgeGroup  { get; set; }
        public virtual Gender Gender { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
