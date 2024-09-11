using AutoMapper;
using DataAccess.Contexts;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly UniqueFashionDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(UniqueFashionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(gs => gs.User)
                .Include(gs => gs.OrderDetails)
                    .ThenInclude(gsd => gsd.Product)
                    .ToListAsync();


            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _context.Orders
                .Include(gs => gs.OrderDetails)
                .ThenInclude(gsd => gsd.Product)
                .FirstOrDefaultAsync(gs => gs.Id == orderId);

            return order == null ? null : _mapper.Map<OrderDto>(order);
        }

        public async Task<int> GetTotalOrdersCountAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Orders.SumAsync(gs => gs.TotalPrice);
        }

        public async Task<List<OrderDto>> GetUserPurchasesAsync(Guid userId)
        {
            var orders = await _context.Orders
                .Include(gs => gs.User)
                .Include(gs => gs.OrderDetails)
                    .ThenInclude(gsd => gsd.Product)                   
                .Where(gs => gs.User.Id == userId)
                .ToListAsync();

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task RefundOrderAsync(Guid orderId, Guid? orderDetailId = null)
        {
            var order = await GetOrderByIdAsync(orderId);
            if (order == null) return;

            if (orderDetailId.HasValue)
            {
                var gameSaleDetail = order.OrderDetails.FirstOrDefault(gsd => gsd.Id == orderDetailId.Value);
                if (gameSaleDetail != null && !gameSaleDetail.IsRefunded)
                {
                    gameSaleDetail.IsRefunded = true;
                    
                }
            }
            else
            {
                foreach (var detail in order.OrderDetails)
                {
                    detail.IsRefunded = true;
                }
                
            }

            await _context.SaveChangesAsync();
        }
    }
}
