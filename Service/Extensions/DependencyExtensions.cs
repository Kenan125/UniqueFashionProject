using DataAccess.Contexts;
using DataAccess.UnitOfWorks;
using Entity.Identities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using Service.Initialization;
using Service.Mapping;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services) 
        {
            services.AddIdentity<AppUser, AppRole>(
                 opt =>
                 {
                     opt.Password.RequiredLength = 6;
                     opt.Password.RequireNonAlphanumeric = false;
                     opt.Password.RequireUppercase = true;
                     opt.Password.RequireLowercase = true;
                     opt.Password.RequireDigit = true;

                     opt.User.RequireUniqueEmail = true;
                     opt.User.AllowedUserNameCharacters = "zxcvbnmasdfghjklqwertyuiop1234567890";
                     opt.Lockout.MaxFailedAccessAttempts = 3;
                     opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

                 }
            ).AddEntityFrameworkStores<UniqueFashionDbContext>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICardInfoService, CardInfoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShippingAddressService, ShippingAddressService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISellerService,SellerService>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<RoleInitializer>();
        }
    }
}
