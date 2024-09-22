using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAccountService _accountService;

        public AuthsController(IAuthService authService, IAccountService accountService)
        {
            _authService = authService;
            _accountService = accountService;
        }

        // New Token Generation Endpoint
        [HttpGet]
        public IActionResult Login()
        {
            //Frontend'de bulunan projeden gelen kullanıcı bilgilerini kontrol ettikten sonra token üretir ve gönderir.
            return Created("", _authService.GenerateToken());
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginRequest)
        {
            var token = await _authService.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            // Get the userId by username
            var userId = await _authService.GetUserIdByUserNameAsync(loginRequest.UserName);

            return Ok(new { token, userId });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.CreateUserAsync(registerRequest);

            if (result == "OK")
            {
                return Ok(new { message = "User registered successfully!" });
            }

            // Return a Bad Request response with the error messages if registration fails
            return BadRequest(new { message = result });
        }

        
    }
}
