using AutoMapper;
using Entity.Dtos;
using Entity.Identities;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IAuthService authService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        public async Task<string> CreateUserAsync(RegisterDto model)
        {
            string message = string.Empty;
            AppUser user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                
                UserName = model.UserName,
                ProfilePictureUrl = model.ProfilePictureUrl // Assuming this is included in RegisterViewModel
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {
                // Assign the default role, e.g., "User"
                var roleResult = await _userManager.AddToRoleAsync(user, "User");

                if (roleResult.Succeeded)
                {
                    message = "OK";
                }
                else
                {
                    // If assigning the role fails, delete the user to avoid having a user without a role
                    await _userManager.DeleteAsync(user);
                    message = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                }
            }
            else
            {
                message = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            }
            return message;
        }

        public async Task<UserDto> FindByIdAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> FindByUserNameAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = _mapper.Map<List<UserDto>>(users);
            foreach (var userViewModel in userViewModels)
            {
                var user = await _userManager.FindByIdAsync(userViewModel.Id.ToString());
                userViewModel.Roles = (await _userManager.GetRolesAsync(user)).ToList(); // Convert to List<string>
            }
            return userViewModels;
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return "Login failed!";
            }

            // Create user claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Generate JWT token
            var token = _authService.GenerateToken(claims);
            return token;
        }

        public async Task<string> SaveProfilePictureAsync(IFormFile formFile)
        {
            var fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
            var extension = Path.GetExtension(formFile.FileName);
            var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return "/images/" + newFileName;
        }
        public async Task<string> UpdateUserAsync(UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id.ToString());
            if (user == null) return "User not found";

            // Update user details
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.UserName = userDto.UserName;
            user.PhoneNumber = userDto.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? "OK" : string.Join(", ", result.Errors.Select(e => e.Description));
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return "User not found";

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded ? "OK" : string.Join(", ", result.Errors.Select(e => e.Description));
        }
    }
}
