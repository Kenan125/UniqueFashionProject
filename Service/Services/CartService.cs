using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CartService : ICartService
    {
        public Task AddToCartAsync(Guid userId, Guid gameId, decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto?> CheckoutAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task ClearCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> GetCartViewModelAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCartAsync(Guid userId, Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}
