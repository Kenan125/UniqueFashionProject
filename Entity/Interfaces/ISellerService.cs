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
        Task<SellerDto> GetSellerByIdAsync(int sellerId);
        Task<bool> CreateSellerAsync(SellerDto model, int userId);
        Task<SellerDto> GetSellerByUserIdAsync(int userId);

    }
}
