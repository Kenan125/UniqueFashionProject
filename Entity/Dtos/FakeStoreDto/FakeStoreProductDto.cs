using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.FakeStoreDto
{
    public class FakeStoreProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }        // Maps to Product.Name
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }     // Maps to Category.Name
        public string Image { get; set; }        // Maps to Product.PrimaryImageUrl
    }
}
