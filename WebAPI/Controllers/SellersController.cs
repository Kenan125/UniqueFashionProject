using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // GET: api/sellers
        [HttpGet]
        public async Task<IActionResult> GetAllSellers()
        {
            var sellers = await _sellerService.GetAllSellersAsync();
            return Ok(sellers);
        }

        // GET: api/sellers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSellerById(int id)
        {
            var seller = await _sellerService.GetSellerByIdAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            return Ok(seller);
        }

        // POST: api/sellers
        [HttpPost]
        public async Task<IActionResult> CreateSeller([FromBody] SellerDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.UserId == null)
            {
                return BadRequest("UserId cannot be null.");
            }

            var userId = model.UserId.Value; // Get the non-nullable int value

            var success = await _sellerService.CreateSellerAsync(model, userId);

            if (!success)
            {
                return BadRequest("Failed to create seller.");
            }

            return Ok("Seller created successfully.");
        }


        // GET: api/sellers/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSellerByUserId(int userId)
        {
            var seller = await _sellerService.GetSellerByUserIdAsync(userId);
            if (seller == null)
            {
                return NotFound();
            }
            return Ok(seller);
        }
    }
}
