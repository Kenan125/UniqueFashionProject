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
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int StockQuantity { get; set; }
        public string? Condition { get; set; }
        public string? Gender { get; set; }
        public string? AgeGroup { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public List<string>? Sizes { get; set; } = new List<string>();
        public string? Color { get; set; }
        public string? PrimaryImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; } = new List<string>();
        public int? SellerId { get; set; }

       
        public virtual Brand Brand { get; set; }
        public virtual Seller Seller { get; set; }     
        public virtual Category Category { get; set; }       
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
