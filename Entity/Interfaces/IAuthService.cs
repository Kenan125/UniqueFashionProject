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
        string GenerateToken(List<Claim> claims);
    }
}
