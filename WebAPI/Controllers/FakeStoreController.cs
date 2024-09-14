using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeStoreController : ControllerBase
    {
        private readonly IProductService _productService;

        public FakeStoreController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("import-fake-products")]
        public async Task<IActionResult> ImportProductsFromFakeStore()
        {
            var result = await _productService.ImportProductsFromFakeStoreAsync();
            if (result)
            {
                return Ok("Products imported successfully.");
            }
            else
            {
                return BadRequest("Failed to import products.");
            }
        }
    }
}
