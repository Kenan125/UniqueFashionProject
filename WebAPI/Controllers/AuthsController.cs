using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginRequest)
        {
            var token = await _authService.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);
            if (token == null) 
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }
    }
}
