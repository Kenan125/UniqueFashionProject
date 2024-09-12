using AutoMapper;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddCategoryAsync(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            await _unitOfWork.GetRepository<Category>().DeleteAsync(categoryId);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categoryRepository = _unitOfWork.GetRepository<Category>();
            var categories = await categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId)
        {
            var repository = _unitOfWork.GetRepository<Category>();
            var category = await repository.GetByIdAsync(categoryId);
            var categoryViewModel = _mapper.Map<CategoryDto>(category);
            return categoryViewModel;
        }
        


        public async Task<bool> UpdateCategoryAsync(Guid id, CategoryDto model)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            _mapper.Map(model, category);
            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
