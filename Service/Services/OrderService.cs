using AutoMapper;
using DataAccess.Contexts;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly UniqueFashionDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(UniqueFashionDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _unitOfWork.GetRepository<Order>().AddAsync(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync(
                includes: new Expression<Func<Order, object>>[]
                {
                    o => o.User,
                    o => o.OrderDetails
                }
            );

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _unitOfWork.GetRepository<Order>().GetAsync(
                o => o.Id == orderId,
                includes: new Expression<Func<Order, object>>[]
                {
                    o => o.OrderDetails
                }
            );

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<int> GetTotalOrdersCountAsync()
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync();
            return orders.Count();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync();
            return orders.Sum(o => o.TotalPrice);
        }

        public async Task<List<OrderDto>> GetUserPurchasesAsync(int userId)
        {
            var orders = await _unitOfWork.GetRepository<Order>().GetAllAsync(
                filter: o => o.UserId == userId,
                includes: new Expression<Func<Order, object>>[]
                {
                    o => o.OrderDetails,
                    o => o.User
                }
            );

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task RefundOrderAsync(int orderId, int? orderDetailId = null)
        {
            var repository = _unitOfWork.GetRepository<Order>();
            var order = await repository.GetAsync(
                o => o.Id == orderId,
                includes: new Expression<Func<Order, object>>[]
                {
                    o => o.OrderDetails
                }
            );

            if (order == null) return;

            if (orderDetailId.HasValue)
            {
                var orderDetail = order.OrderDetails.FirstOrDefault(od => od.Id == orderDetailId.Value);
                if (orderDetail != null && !orderDetail.IsRefunded)
                {
                    orderDetail.IsRefunded = true;
                    await _unitOfWork.GetRepository<OrderDetail>().UpdateAsync(orderDetail);
                }
            }
            else
            {
                foreach (var detail in order.OrderDetails)
                {
                    if (!detail.IsRefunded)
                    {
                        detail.IsRefunded = true;
                        await _unitOfWork.GetRepository<OrderDetail>().UpdateAsync(detail);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
