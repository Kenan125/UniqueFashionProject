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
