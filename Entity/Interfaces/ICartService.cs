using Entity.Dtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(int userId, int gameId, decimal price);  // Changed to Guid
        Task<Cart> GetCartAsync(int userId);  // Changed to Guid
        Task<CartDto> GetCartViewModelAsync(int userId);  // Changed to Guid
        Task ClearCartAsync(int userId);  // Changed to Guid
        Task<OrderDto?> CheckoutAsync(int userId);  // Changed to Guid
        Task RemoveFromCartAsync(int userId, int gameId);  // Changed to Guid
    }
}
