using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IUserService
    {
        Task<List<OrderDto>> GetPurchaseHistoryAsync(Guid userId);
        Task<UserDto> GetUserProfileAsync(Guid userId);
        Task<Guid?> FindUserIdByUserNameAsync(string username);
        Task<bool> RefundGameAsync(Guid userId, Guid gameId);
        Task<bool> UpdateUserProfileAsync(Guid userId, UserDto model);
        
    }
}
