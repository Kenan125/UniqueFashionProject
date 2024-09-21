using AutoMapper;
using DataAccess.Contexts;
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
        private readonly UniqueFashionDbContext _context;
        private readonly IMapper _mapper;

        public CartService(UniqueFashionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task AddToCartAsync(int userId, int gameId, decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto?> CheckoutAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task ClearCartAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> GetCartViewModelAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCartAsync(int userId, int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
