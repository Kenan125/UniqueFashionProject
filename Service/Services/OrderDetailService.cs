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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly UniqueFashionDbContext _context;

        public OrderDetailService(UniqueFashionDbContext context)
        {
            _context = context;
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(Guid orderDetailId)
        {
            return await _context.OrderDetails.Include(od=>od.Product).FirstOrDefaultAsync(od=>od.Id == orderDetailId);
                
        }

        public async Task<bool> RefundOrderDetailAsync(Guid orderDetailId)
        {
            var gameSaleDetail = await GetOrderDetailByIdAsync(orderDetailId);
            if (gameSaleDetail != null && !gameSaleDetail.IsRefunded)
            {
                gameSaleDetail.IsRefunded = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
