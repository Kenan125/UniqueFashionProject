using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<SellerDto>> GetAllSellersAsync();
        Task<SellerDto> GetSellerByIdAsync(Guid sellerId);
        Task<bool> CreateSellerAsync(SellerDto model, Guid userId);
        Task<SellerDto> GetSellerByUserIdAsync(Guid userId);

    }
}
