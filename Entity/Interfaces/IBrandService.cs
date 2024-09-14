using Entity.Dtos;
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
        Task<BrandDto> GetBrandByIdAsync(int brandId);
        Task<bool> AddBrandAsync(BrandDto model);
        Task<bool> UpdateBrandAsync(int id, BrandDto model);
        Task<bool> DeleteBrandAsync(int brandId);
    }
}
