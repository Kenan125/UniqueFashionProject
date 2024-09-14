using AutoMapper;
using Entity.Dtos;
using Entity.Dtos.FakeStoreDto;
using Entity.Entities;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<CardInfo, CardInfoDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<ShippingAddress, ShippingAddressDto>().ReverseMap();
            CreateMap<Size, SizeDto>().ReverseMap();
            // Map FakeStoreProductDto to Product
            CreateMap<FakeStoreProductDto, Product>()
    .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore the Id mapping
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
    .ForMember(dest => dest.PrimaryImageUrl, opt => opt.MapFrom(src => src.Image))
    .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => new List<string> { src.Image }))
    // Ignore the Category property to prevent AutoMapper from trying to map it directly
    .ForMember(dest => dest.Category, opt => opt.Ignore())
    // Also ignore CategoryId if you'll set it manually
    .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
    // Map other properties as needed
    .ForMember(dest => dest.Gender, opt => opt.Ignore())
    .ForMember(dest => dest.GenderId, opt => opt.Ignore())
    .ForMember(dest => dest.AgeGroup, opt => opt.Ignore())
    .ForMember(dest => dest.AgeGroupId, opt => opt.Ignore())
    .ForMember(dest => dest.BrandId, opt => opt.Ignore())
    .ForMember(dest => dest.SizeId, opt => opt.Ignore())
    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => "New"))
    .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => 100))
    .ForMember(dest => dest.SellerId, opt => opt.MapFrom(src => 1)) // Default seller ID
    .ForMember(dest => dest.Color, opt => opt.MapFrom(src => "Default Color"))
    .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => (decimal?)null));
    




        }
    }
}
