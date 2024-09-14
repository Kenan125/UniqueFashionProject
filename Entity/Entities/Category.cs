using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public ICollection<Category> ChildCategories { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
