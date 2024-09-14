using AutoMapper;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddBrandAsync(BrandDto model)
        {
            var brand = _mapper.Map<Brand>(model);



            await _unitOfWork.GetRepository<Brand>().AddAsync(brand);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteBrandAsync(int brandId)
        {
            var repository = _unitOfWork.GetRepository<Brand>();


            await repository.DeleteAsync(brandId);

            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool includeDeleted = false)
        {
            var products = await _unitOfWork.GetRepository<Brand>().GetAllAsync(
                filter: g => includeDeleted || !g.IsDeleted, // Include soft-deleted games based on the flag
                includes: new Expression<Func<Brand, object>>[]
                {
                    g=> g.Products
            

                }
            );

            return _mapper.Map<List<BrandDto>>(products);
        }

        public async Task<BrandDto> GetBrandByIdAsync(int brandId)
        {
            var repository = _unitOfWork.GetRepository<Brand>();
            var product = await repository.GetAllAsync(
                filter: g => g.Id == brandId,
                includes: new Expression<Func<Brand, object>>[]
                {

                    g => g.Products
                   
                }
            );

            if (product == null || !product.Any())
            {
                return null;
            }

            var productDto = _mapper.Map<BrandDto>(product.FirstOrDefault());

            return productDto;
        }

        public async Task<bool> UpdateBrandAsync(int id, BrandDto model)
        {
            // Fetch the product using the id from the URL
            var brand = await _unitOfWork.GetRepository<Brand>().GetByIdAsync(id);

            if (brand == null)
                return false;

            // Map the updated values from the DTO to the existing product entity
            _mapper.Map(model, brand);

            // Update the product and commit the changes
            await _unitOfWork.GetRepository<Brand>().UpdateAsync(brand);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
