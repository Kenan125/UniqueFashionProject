using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ISizeService
    {
        Task CreateSizeAsync(SizeDto model);
        Task<SizeDto> GetSizeByIdAsync(int sizeId);
        Task<List<SizeDto>> GetAllSizesAsync();  // Optionally, get all sizes
        Task UpdateSizeAsync(SizeDto model);
        Task DeleteSizeAsync(int sizeId);
    }
}
