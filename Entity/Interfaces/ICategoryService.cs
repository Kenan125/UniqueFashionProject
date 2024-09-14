using Entity.Dtos;
using Entity.Entities;
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
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<bool> AddCategoryAsync(CategoryDto model);
        Task<bool> UpdateCategoryAsync(int id, CategoryDto model);
        
        Task DeleteCategoryAsync(int categoryId);
    }
}
