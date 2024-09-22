using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class ShippingAddressesController : ControllerBase
    {
        private readonly IShippingAddressService _shippingAddressService;

        public ShippingAddressesController(IShippingAddressService shippingAddressService)
        {
            _shippingAddressService = shippingAddressService;
        }


        
        
        [HttpGet("user")]
        public async Task<IActionResult> GetShippingAddressByUserId()
        {
            var userIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"Extracted userId from token: {userIdClaim}");

            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "User not authenticated." });
            }

            int userId = int.Parse(userIdClaim); // Convert userId from string to int

            var address = await _shippingAddressService.GetShippingAddressByUserIdAsync(userId);
            if (address == null)
            {
                return NotFound(new { message = "Shipping address not found." });
            }

            return Ok(address);
        }

        // Get shipping address by specific address ID
        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetShippingAddressById(int addressId)
        {
            var address = await _shippingAddressService.GetShippingAddressByIdAsync(addressId);
            if (address == null)
            {
                return NotFound(new { message = "Shipping address not found." });
            }
            return Ok(address);
        }

        // Create a new shipping address
        [HttpPost]
        public async Task<IActionResult> CreateShippingAddress([FromBody] ShippingAddressDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _shippingAddressService.CreateShippingAddressAsync(model);
            return Ok(new { message = "Shipping address created successfully." });
        }

        // Update an existing shipping address
        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateShippingAddress(int addressId, [FromBody] ShippingAddressDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAddress = await _shippingAddressService.GetShippingAddressByIdAsync(addressId);
            if (existingAddress == null)
            {
                return NotFound(new { message = "Shipping address not found." });
            }

            model.Id = addressId; // Ensure the model's ID matches the address being updated
            await _shippingAddressService.UpdateShippingAddressAsync(model);
            return Ok(new { message = "Shipping address updated successfully." });
        }

        // Delete a shipping address
        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteShippingAddress(int addressId)
        {
            var existingAddress = await _shippingAddressService.GetShippingAddressByIdAsync(addressId);
            if (existingAddress == null)
            {
                return NotFound(new { message = "Shipping address not found." });
            }

            await _shippingAddressService.DeleteShippingAddressAsync(addressId);
            return Ok(new { message = "Shipping address deleted successfully." });
        }
    }
}
