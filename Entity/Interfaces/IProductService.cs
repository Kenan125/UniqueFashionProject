using Entity.Dtos;

namespace Entity.Interfaces
{
    public interface IProductService
    {

        Task<bool> AddProductAsync(ProductDto model);

        Task<bool> UpdateProductAsync(int id, ProductDto model);

        Task<bool> DeleteProductAsync(int productId);
        Task<bool> SoftDeleteProductAsync(int productId);

        Task<ProductDto> GetProductByIdAsync(int productId);

        Task<List<ProductDto>> GetAllProductsAsync(bool includeDeleted = false);
        

        Task<List<ProductDto>> SearchProductsAsync(string searchTerm, bool includeDeleted = false);

        Task<List<ProductDto>> GetProductsByCategoryAsync(int categoryId, bool includeDeleted = false);
        Task<List<ProductDto>> GetProductsByBrandAsync(int brandId, bool includeDeleted = false);

    }
}
