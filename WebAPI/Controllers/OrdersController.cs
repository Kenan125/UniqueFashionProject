using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = new Order
            {
                UserId = model.UserId,
                TotalQuantity = model.TotalQuantity,
                TotalPrice = model.TotalPrice,
                IsDiscountApplied = model.IsDiscountApplied,
                ShippingAddressId = model.ShippingAddressId
            };

            await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        

       
        

        // GET: api/orders/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPurchases(Guid userId)
        {
            var orders = await _orderService.GetUserPurchasesAsync(userId);
            return Ok(orders);
        }

        // POST: api/orders/{id}/refund
        [HttpPost("{id}/refund")]
        public async Task<IActionResult> RefundOrder(Guid id, [FromQuery] Guid? orderDetailId = null)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderService.RefundOrderAsync(id, orderDetailId);
            return NoContent();
        }
    }
}
