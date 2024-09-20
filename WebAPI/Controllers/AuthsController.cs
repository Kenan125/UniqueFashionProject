using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

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
        // GET USER BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _accountService.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }
            return Ok(user);
        }
        // EDIT USER (UPDATE)
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] UserDto userUpdateRequest)
        {
            var user = await _accountService.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            // Update the user details
            user.FirstName = userUpdateRequest.FirstName;
            user.LastName = userUpdateRequest.LastName;
            user.Email = userUpdateRequest.Email;
            user.PhoneNumber = userUpdateRequest.PhoneNumber;
            user.UserName = userUpdateRequest.UserName;

            // Optionally handle password or other sensitive data here

            var updateResult = await _accountService.UpdateUserAsync(user);
            if (updateResult == "OK")
            {
                return Ok(new { message = "User updated successfully." });
            }

            return BadRequest(new { message = updateResult });
        }

        // DELETE USER (SOFT DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _accountService.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            var deleteResult = await _accountService.DeleteUserAsync(id);
            if (deleteResult == "OK")
            {
                return Ok(new { message = "User deleted successfully." });
            }

            return BadRequest(new { message = deleteResult });
        }
    }
}
