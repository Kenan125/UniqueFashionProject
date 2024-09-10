using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        public Task<Guid?> FindUserIdByUserNameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetPurchaseHistoryAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserProfileAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefundGameAsync(Guid userId, Guid gameId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserProfileAsync(Guid userId, UserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
