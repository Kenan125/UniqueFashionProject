using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        public Task AddCategoryAsync(CategoryDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(CategoryDto model)
        {
            throw new NotImplementedException();
        }
    }
}
