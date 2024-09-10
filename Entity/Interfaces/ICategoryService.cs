using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId);
        Task AddCategoryAsync(CategoryDto model);
        Task UpdateCategoryAsync(CategoryDto model);
        Task DeleteCategoryAsync(Guid categoryId);
    }
}
