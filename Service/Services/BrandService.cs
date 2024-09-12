using AutoMapper;
using Entity.Dtos.BrandDtos;
using Entity.Dtos.ProductDtos;
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

        public Task AddBrandAsync(BrandDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBrandAsync(Guid brandId)
        {
            throw new NotImplementedException();
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

        public Task<BrandDto> GetBrandByIdAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBrandAsync(BrandDto model)
        {
            throw new NotImplementedException();
        }
    }
}
