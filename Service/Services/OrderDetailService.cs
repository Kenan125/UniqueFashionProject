using AutoMapper;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using System.Linq.Expressions;

namespace Service.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDetailDto> GetOrderDetailByIdAsync(int orderDetailId)
        {
            var orderDetail = await _unitOfWork.GetRepository<OrderDetail>().GetAsync(
                od => od.Id == orderDetailId,
                includes: new Expression<Func<OrderDetail, object>>[]
                {
                    od => od.Product
                }
            );

            return _mapper.Map<OrderDetailDto>(orderDetail);

        }

        public async Task<bool> RefundOrderDetailAsync(int orderDetailId)
        {
            var repository = _unitOfWork.GetRepository<OrderDetail>();
            var orderDetail = await repository.GetByIdAsync(orderDetailId);
            if (orderDetail != null && !orderDetail.IsRefunded)
            {
                orderDetail.IsRefunded = true;
                await repository.UpdateAsync(orderDetail);
                await _unitOfWork.CommitAsync();
                return true;
            }
            return false;
        }
    }
}
