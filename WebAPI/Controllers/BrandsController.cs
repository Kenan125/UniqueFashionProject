using Entity.Dtos.BrandDtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var products = await _brandService.GetAllBrandsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(Guid id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);
            if (brand == null) { return NotFound(); }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto brandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _brandService.AddBrandAsync(brandDto);
            if (!result)
            {
                return BadRequest("Error occured while creating the brand.");
            }
            return Ok("Brand created successfully!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(Guid id, [FromBody] BrandDto brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _brandService.UpdateBrandAsync(id,brand);
            if (!result)
            {
                return NotFound("Brand not found.");
            }
            return Ok("Product updated successfully!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
            var result = await _brandService.DeleteBrandAsync(id);
            if (!result)
            {
                return NotFound("Brand not found");
            }
            return Ok("Brand deleted successfully.");
        }
    }
}
