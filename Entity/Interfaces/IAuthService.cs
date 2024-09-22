using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken();
        Task<string> AuthenticateAsync(string userName, string password);
        Task<string> GetUserIdByUserNameAsync(string userName);
    }
}
