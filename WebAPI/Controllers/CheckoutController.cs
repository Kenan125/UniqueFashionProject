using AutoMapper;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CheckoutController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICardInfoService _cardInfoService;
        private readonly IShippingAddressService _shippingAddressService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CheckoutController(
            IOrderService orderService,
            ICardInfoService cardInfoService,
            IShippingAddressService shippingAddressService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _orderService = orderService;
            _cardInfoService = cardInfoService;
            _shippingAddressService = shippingAddressService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int userId = GetUserId();

            // Save card info
            model.CardInfo.UserId = userId;
            await _cardInfoService.AddCardAsync(model.CardInfo);

            // Save shipping address
            model.ShippingAddress.UserId = userId;
            await _shippingAddressService.CreateShippingAddressAsync(model.ShippingAddress);

            // Create order
            var order = new Order
            {
                UserId = userId,
                TotalQuantity = model.CartItems.Sum(item => item.Quantity),
                TotalPrice = model.CartItems.Sum(item => item.Price * item.Quantity),
                CreatedDate = DateTime.UtcNow,
                ShippingAddressId = model.ShippingAddress.Id,
                OrderDetails = new List<OrderDetail>()
            };

            var productRepository = _unitOfWork.GetRepository<Product>();

            foreach (var item in model.CartItems)
            {
                var product = await productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    return BadRequest($"Product with ID {item.ProductId} not found.");

                // Update stock
                if (product.StockQuantity < item.Quantity)
                    return BadRequest($"Insufficient stock for product {product.Name}.");

                product.StockQuantity -= item.Quantity;
                await productRepository.UpdateAsync(product);

                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    UnitPrice = item.Price,
                    Quantity = item.Quantity,
                    Discount = 0,
                    IsRefunded = false
                };
                order.OrderDetails.Add(orderDetail);
            }

            await _orderService.CreateOrderAsync(order);
            await _unitOfWork.CommitAsync();

            // Simulate payment processing
            bool paymentSuccess = SimulatePayment(model.CardInfo, order.TotalPrice);
            if (!paymentSuccess)
            {
                return BadRequest("Payment failed.");
            }

            return Ok(new { OrderId = order.Id });
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        private bool SimulatePayment(CardInfoDto cardInfo, decimal amount)
        {
            // Implement fake payment logic here
            // For the purpose of the project, we'll assume payment is always successful
            return true;
        }
    }
}
