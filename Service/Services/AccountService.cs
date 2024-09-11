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

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateUserAsync(RegisterDto model)
        {
            string message = string.Empty;
            AppUser user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
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

        public async Task<UserDto> FindByIdAsync(Guid userId)
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
            if (user == null)
            {
                return "User not found!";
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
            {
                return "OK";
            }
            return "Login Failed!";
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
    }
}
