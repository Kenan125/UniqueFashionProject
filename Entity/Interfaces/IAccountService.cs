using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);
        Task<UserDto> FindByUserNameAsync(string name);
        Task<UserDto> FindByIdAsync(int userId);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<string> SaveProfilePictureAsync(IFormFile formFile);
        Task<string> UpdateUserAsync(UserDto userDto);
        Task<string> DeleteUserAsync(int id);


    }
}
