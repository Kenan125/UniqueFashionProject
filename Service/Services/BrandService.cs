using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BrandService : IBrandService
    {
        public Task AddBrandAsync(BrandDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBrandAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            throw new NotImplementedException();
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
