using Entity.Dtos.ProductDtos;

namespace Entity.Interfaces
{
    public interface IProductService
    {

        Task<bool> AddProductAsync(ProductCreateDto model);

        Task<bool> UpdateProductAsync(Guid id, ProductUpdateDto model);

        Task<bool> DeleteProductAsync(Guid productId);
        Task<bool> SoftDeleteProductAsync(Guid productId);

        Task<ProductDto> GetProductByIdAsync(Guid productId);

        Task<List<ProductDto>> GetAllProductsAsync(bool includeDeleted = false);
        

        Task<List<ProductDto>> SearchProductsAsync(string searchTerm, bool includeDeleted = false);

        Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId, bool includeDeleted = false);
        Task<List<ProductDto>> GetProductsByBrandAsync(Guid brandId, bool includeDeleted = false);

    }
}
