using Entity.Dtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<List<OrderDto>> GetUserPurchasesAsync(int userId);
        Task RefundOrderAsync(int orderId, int? orderDetailId = null);
        Task<int> GetTotalOrdersCountAsync();
        Task<decimal> GetTotalRevenueAsync();
       
        Task<List<OrderDto>> GetAllOrdersAsync();
    }
}
