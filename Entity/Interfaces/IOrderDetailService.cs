using Entity.Dtos;

namespace Entity.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetailDto> GetOrderDetailByIdAsync(int orderDetailId);
        Task<bool> RefundOrderDetailAsync(int orderDetailId);


    }
}
