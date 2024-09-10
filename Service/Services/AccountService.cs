using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        public Task<string> CreateUserAsync(RegisterDto model)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> FindByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> FindByUserNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(LoginDto model)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveProfilePictureAsync(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
