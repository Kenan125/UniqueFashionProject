using Entity.Identities;
using Entity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        // Method for authenticating the user and generating the token
        public async Task<string> AuthenticateAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                return null; // Invalid credentials
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Generate JWT token
            return GenerateToken();
        }

        public string GenerateToken()
        {
            var jwtDefaults = _configuration.GetSection("JwtDefaults");
            var secretKey = jwtDefaults["SecretKey"];

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, "Admin")
            };

            JwtSecurityToken token = new JwtSecurityToken(issuer: jwtDefaults["ValidIssuer"], audience: jwtDefaults["ValidAudience"], claims: claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtDefaults["expires"])), signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
        public async Task<string> GetUserIdByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return user.Id.ToString();
            }
            return null;
        }
    }
}
