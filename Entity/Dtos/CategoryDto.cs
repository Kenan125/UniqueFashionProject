namespace Entity.Dtos
{
    public class CategoryDto
    {

        public string Name { get; set; }


        public int? ParentCategoryId { get; set; }
        //public CategoryDto? ParentCategory { get; set; }

        //public ICollection<CategoryDto> ChildCategories { get; set; } = new List<CategoryDto>();

        //public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
