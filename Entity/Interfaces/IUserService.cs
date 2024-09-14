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
        Task<List<OrderDto>> GetPurchaseHistoryAsync(int userId);
        Task<UserDto> GetUserProfileAsync(int userId);
        Task<int?> FindUserIdByUserNameAsync(string username);
        Task<bool> RefundProductAsync(int userId, int gameId);
        Task<bool> UpdateUserProfileAsync(int userId, UserDto model, ChangePasswordDto pswchng);
        
    }
}
