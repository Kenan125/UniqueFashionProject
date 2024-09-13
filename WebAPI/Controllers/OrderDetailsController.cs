using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        // GET: api/orderdetails/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(Guid id)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            // Map to DTO if needed
            var orderDetailDto = new OrderDetailDto
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                UnitPrice = orderDetail.UnitPrice,
                Discount = orderDetail.Discount,
                IsRefunded = orderDetail.IsRefunded
            };

            return Ok(orderDetailDto);
        }

        

        

        

        // POST: api/orderdetails/{id}/refund
        [HttpPost("{id}/refund")]
        public async Task<IActionResult> RefundOrderDetail(Guid id)
        {
            var result = await _orderDetailService.RefundOrderDetailAsync(id);
            if (!result)
            {
                return NotFound("Order detail not found or already refunded.");
            }

            return NoContent();
        }
    }
}
