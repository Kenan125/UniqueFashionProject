using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public CategoryDto? ParentCategory { get; set; }

        public ICollection<CategoryDto> ChildCategories { get; set; } = new List<CategoryDto>();

        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
