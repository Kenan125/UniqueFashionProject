using Entity.Entities;

namespace Entity.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId);
        Task<bool> RefundOrderDetailAsync(int orderDetailId);


    }
}
