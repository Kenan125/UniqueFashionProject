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
        Task AddToCartAsync(Guid userId, Guid gameId, decimal price);  // Changed to Guid
        Task<Cart> GetCartAsync(Guid userId);  // Changed to Guid
        Task<CartDto> GetCartViewModelAsync(Guid userId);  // Changed to Guid
        Task ClearCartAsync(Guid userId);  // Changed to Guid
        Task<OrderDto?> CheckoutAsync(Guid userId);  // Changed to Guid
        Task RemoveFromCartAsync(Guid userId, Guid gameId);  // Changed to Guid
    }
}
