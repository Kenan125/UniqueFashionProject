using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        public Task CreateOrderAsync(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrderByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalOrdersCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalRevenueAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetUserPurchasesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefundOrderAsync(Guid orderId, Guid? orderDetailId = null)
        {
            throw new NotImplementedException();
        }
    }
}
