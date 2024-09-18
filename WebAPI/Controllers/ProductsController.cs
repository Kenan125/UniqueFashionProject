using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]        
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        //[Authorize(Roles = "Admin, Seller")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.AddProductAsync(productDto);
            if (!result)
            {
                return BadRequest("Error occurred while creating the product.");
            }
            return Ok("Product created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Pass the id and the DTO to the service
            var result = await _productService.UpdateProductAsync(id, productDto);

            if (!result)
            {
                return NotFound("Product not found.");
            }

            return Ok("Product updated successfully.");
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string term)
        {
            var products = await _productService.SearchProductsAsync(term);
            return Ok(products);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId, [FromQuery] bool includeDeleted = false)
        {
            var product = await _productService.GetProductsByCategoryAsync(categoryId, includeDeleted);
            if (product == null || !product.Any())
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult> GetProductByBrandId(int brandId, [FromQuery] bool includeDeleted = false)
        {
            var product = await _productService.GetProductsByBrandAsync(brandId, includeDeleted);
            if (product == null || !product.Any())
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
            {
                return NotFound("Product not found.");
            }

            return Ok("Product deleted successfully.");
        }
        [HttpPut("softdelete/{productId}")]
        public async Task<IActionResult> SoftDeleteProduct(int productId)
        {
            var result = await _productService.SoftDeleteProductAsync(productId);

            if (!result)
            {
                return NotFound("Product not found or could not be soft deleted.");
            }

            return Ok("Product soft deleted successfully.");
        }
        


    }
}
