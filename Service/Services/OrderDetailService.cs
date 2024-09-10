using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        public Task<OrderDto> GetOrderDetailByIdAsync(Guid orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefundOrderDetailAsync(Guid orderDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
