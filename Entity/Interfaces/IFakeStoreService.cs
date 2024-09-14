using Entity.Dtos.FakeStoreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IFakeStoreService
    {
        Task<List<FakeStoreProductDto>> GetProductsAsync();
    }
}
