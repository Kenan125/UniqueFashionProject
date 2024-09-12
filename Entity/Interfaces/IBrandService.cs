using Entity.Dtos.BrandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool includeDeleted = false);
        Task<BrandDto> GetBrandByIdAsync(Guid brandId);
        Task AddBrandAsync(BrandDto model);
        Task UpdateBrandAsync(BrandDto model);
        Task DeleteBrandAsync(Guid brandId);
    }
}
