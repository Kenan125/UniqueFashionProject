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
        public async Task<IActionResult> GetOrderById(int id)
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
                return BadRequest(ModelState); // This will help if something is missing from the model
            }

            try
            {
                var order = new Order
                {
                    UserId = model.UserId,
                    TotalQuantity = model.TotalQuantity,
                    TotalPrice = model.TotalPrice,
                    IsDiscountApplied = model.IsDiscountApplied,
                    ShippingAddressId = model.ShippingAddressId // Make sure this field is not null if required
                };

                await _orderService.CreateOrderAsync(order);

                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Error creating order: {ex.Message}");
                return StatusCode(500, "An error occurred while creating the order.");
            }
        }







        // GET: api/orders/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPurchases(int userId)
        {
            var orders = await _orderService.GetUserPurchasesAsync(userId);
            return Ok(orders);
        }

        // POST: api/orders/{id}/refund
        [HttpPost("{id}/refund")]
        public async Task<IActionResult> RefundOrder(int id, [FromQuery] int? orderDetailId = null)
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
