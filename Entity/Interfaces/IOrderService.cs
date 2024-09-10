using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(OrderDto order);
        Task<OrderDto> GetOrderByIdAsync(Guid orderId);
        Task<List<OrderDto>> GetUserPurchasesAsync(Guid userId);
        Task<bool> RefundOrderAsync(Guid orderId, Guid? orderDetailId = null);
        Task<int> GetTotalOrdersCountAsync();
        Task<decimal> GetTotalRevenueAsync();
       
        Task<List<OrderDto>> GetAllOrdersAsync();
    }
}
