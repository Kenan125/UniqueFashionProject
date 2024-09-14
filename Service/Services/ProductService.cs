using AutoMapper;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFakeStoreService _fakeStoreService;


        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IFakeStoreService fakeStoreService)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fakeStoreService = fakeStoreService;
        }

        public async Task<bool> AddProductAsync(ProductDto model)
        {
            var product = _mapper.Map<Product>(model);

            

            await _unitOfWork.GetRepository<Product>().AddAsync(product);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var repository = _unitOfWork.GetRepository<Product>();


            await repository.DeleteAsync(productId);

            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync(bool includeDeleted = false)
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(
                filter: g => includeDeleted || !g.IsDeleted, // Include soft-deleted games based on the flag
                includes: new Expression<Func<Product, object>>[]
                {
            g => g.Brand,
            g => g.Seller,           
            g => g.Category,
            g=> g.Size
            
                }
            );

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var repository = _unitOfWork.GetRepository<Product>();
            var product = await repository.GetAllAsync(
                filter: g => g.Id == productId,
                includes: new Expression<Func<Product, object>>[]
                {
            
                    g => g.Reviews,            
                    g=>g.Category,
                    g=>g.Size
                }
            );

            if (product == null || !product.Any())
            {
                return null;
            }

            var productDto = _mapper.Map<ProductDto>(product.FirstOrDefault());

            return productDto;
        }

        

        public async Task<List<ProductDto>> GetProductsByBrandAsync(int brandId, bool includeDeleted = false)
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(
                filter: g => (includeDeleted || !g.IsDeleted) && g.BrandId == brandId
                
            );

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(int categoryId, bool includeDeleted = false)
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(
                filter: g => (includeDeleted || !g.IsDeleted) && g.CategoryId == categoryId 
                
            );

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string searchTerm, bool includeDeleted = false)
        {
            searchTerm = searchTerm.ToLower();

            var games = await _unitOfWork.GetRepository<Product>().GetAllAsync(
                filter: g => (includeDeleted || !g.IsDeleted) &&
                             (g.Name.ToLower().Contains(searchTerm)),
                includes: new Expression<Func<Product, object>>[]
                {           
                    g => g.Reviews,
                    g => g.Brand            
                }
            );

            return _mapper.Map<List<ProductDto>>(games);
        }

        public async Task<bool> SoftDeleteProductAsync(int productId)
        {
            var repository = _unitOfWork.GetRepository<Product>();
            var product = await repository.GetByIdAsync(productId);
            if (product == null)
            {
                return false;
            }

            product.IsDeleted = true;

            await repository.UpdateAsync(product);

            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateProductAsync(int id, ProductDto model)
        {
            // Fetch the product using the id from the URL
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);

            if (product == null)
                return false;

            // Map the updated values from the DTO to the existing product entity
            _mapper.Map(model, product);

            // Update the product and commit the changes
            await _unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await _unitOfWork.CommitAsync();

            return true;
        }
        public async Task<bool> ImportProductsFromFakeStoreAsync()
        {
            var fakeProducts = await _fakeStoreService.GetProductsAsync();

            foreach (var fakeProductDto in fakeProducts)
            {
                // Map to Product entity
                var product = _mapper.Map<Product>(fakeProductDto);

                // Resolve CategoryId
                product.CategoryId = await ResolveCategoryIdAsync(fakeProductDto.Category);

                // Set default BrandId and SizeId or resolve based on your logic
                product.BrandId = await ResolveBrandIdAsync("Default Brand");
                product.SizeId = await ResolveSizeIdAsync("Default Size");

                // Add product to repository
                await _unitOfWork.GetRepository<Product>().AddAsync(product);
            }

            await _unitOfWork.CommitAsync();
            return true;
        }

        private async Task<int> ResolveCategoryIdAsync(string categoryName)
        {
            var categoryRepo = _unitOfWork.GetRepository<Category>();
            var category = await categoryRepo.GetAsync(c => c.Name == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName,
                    ParentCategoryId = null // Adjust if needed
                };
                await categoryRepo.AddAsync(category);
                await _unitOfWork.CommitAsync();
            }

            return category.Id;
        }

        private async Task<int> ResolveBrandIdAsync(string brandName)
        {
            var brandRepo = _unitOfWork.GetRepository<Brand>();
            var brand = await brandRepo.GetAsync(b => b.Name == brandName);

            if (brand == null)
            {
                brand = new Brand
                {
                    Name = brandName
                };
                await brandRepo.AddAsync(brand);
                await _unitOfWork.CommitAsync();
            }

            return brand.Id;
        }

        private async Task<int> ResolveSizeIdAsync(string sizeName)
        {
            var sizeRepo = _unitOfWork.GetRepository<Size>();
            var size = await sizeRepo.GetAsync(s => s.Name == sizeName);

            if (size == null)
            {
                size = new Size
                {
                    Name = sizeName
                };
                await sizeRepo.AddAsync(size);
                await _unitOfWork.CommitAsync();
            }

            return size.Id;
        }
    }
}
