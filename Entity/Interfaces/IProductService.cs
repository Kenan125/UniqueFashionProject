using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(ProductDto model);

        Task<bool> UpdateProductAsync(ProductDto model);

        Task<bool> DeleteProductAsync(Guid productId);
        Task<bool> SoftDeleteProductAsync(Guid productId);

        Task<ProductDto> GetProductByIdAsync(Guid productId);

        Task<List<ProductDto>> GetAllProductsAsync(bool includeDeleted = false);
        Task<List<ProductDto>> GetProductsAsync(string searchTerm, int? categoryId, bool includeDeleted);

        Task<List<ProductDto>> SearchProductsAsync(string searchTerm, bool includeDeleted = false);

        Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId, bool includeDeleted = false);
        Task<List<ProductDto>> GetProductsByBrandAsync(Guid brandId);
        
    }
}
