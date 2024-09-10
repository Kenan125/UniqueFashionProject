using Entity.Entities;
using Entity.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class UniqueFashionDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public UniqueFashionDbContext(DbContextOptions<UniqueFashionDbContext> options) : base(options) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CardInfo> CardInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}
