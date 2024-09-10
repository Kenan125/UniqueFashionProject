using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SizeService : ISizeService
    {
        public Task CreateSizeAsync(SizeDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSizeAsync(Guid sizeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SizeDto>> GetAllSizesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SizeDto> GetSizeByIdAsync(Guid sizeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSizeAsync(SizeDto model)
        {
            throw new NotImplementedException();
        }
    }
}
