using Entity.Entities;

namespace Entity.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> GetOrderDetailByIdAsync(Guid orderDetailId);
        Task<bool> RefundOrderDetailAsync(Guid orderDetailId);


    }
}
