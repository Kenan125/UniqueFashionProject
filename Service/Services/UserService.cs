using AutoMapper;
using DataAccess.Contexts;
using Entity.Dtos;
using Entity.Identities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly UniqueFashionDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UniqueFashionDbContext context, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> FindUserIdByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user?.Id;
        }

        public async Task<List<OrderDto>> GetPurchaseHistoryAsync(int userId)
        {
            var purchaseHistory = await _context.Orders
                .Include(gs => gs.OrderDetails)
                .ThenInclude(gsd => gsd.Product)
                .Where(gs => gs.UserId == userId)
                .OrderByDescending(gs => gs.CreatedDate)
                .ToListAsync();

            return _mapper.Map<List<OrderDto>>(purchaseHistory);
        }

        public async Task<UserDto> GetUserProfileAsync(int userId)
        {
            var user = await _userManager.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> RefundProductAsync(int userId, int productId)
        {
            var orderDetail = await _context.OrderDetails
                .Include(gsd => gsd.Order)
                .FirstOrDefaultAsync(gsd => gsd.ProductId == productId && gsd.Order.UserId == userId && !gsd.IsRefunded);

            if (orderDetail != null)
            {
                orderDetail.IsRefunded = true;
                _context.OrderDetails.Update(orderDetail);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateUserProfileAsync(int userId, UserDto model,ChangePasswordDto pswchng)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(model.ProfilePictureUrl))
            {
                user.ProfilePictureUrl = model.ProfilePictureUrl;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            if (!string.IsNullOrEmpty(model.UserName) && model.UserName != user.UserName)
            {
                var usernameExists = await _userManager.FindByNameAsync(model.UserName);
                if (usernameExists == null)
                {
                    user.UserName = model.UserName;
                }
                else
                {
                    return false;
                }
            }

            user.PhoneNumber = model.PhoneNumber;

            if (!string.IsNullOrEmpty(pswchng.CurrentPassword) && !string.IsNullOrEmpty(pswchng.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, pswchng.CurrentPassword, pswchng.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    return false; // Password change failed
                }
            }

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
