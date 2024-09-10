using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        public Task<bool> AddProductAsync(ProductDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllProductsAsync(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsAsync(string searchTerm, int? categoryId, bool includeDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByBrandAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId, bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> SearchProductsAsync(string searchTerm, bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(ProductDto model)
        {
            throw new NotImplementedException();
        }
    }
}
