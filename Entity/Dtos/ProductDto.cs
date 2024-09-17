using Entity.Entities;

namespace Entity.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Condition { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public List<string>? Sizes { get; set; } = new List<string>();
        public int CategoryId { get; set; }

        public int BrandId { get; set; }
        
        public string Color { get; set; }
        public string PrimaryImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public int SellerId { get; set; }


    }
}
