using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDto> GetOrderDetailByIdAsync(Guid orderDetailId);
        Task<bool> RefundOrderDetailAsync(Guid orderDetailId);       

    }
}
