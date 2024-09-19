using Entity.Entities;
using Entity.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class UniqueFashionDbContext : IdentityDbContext<AppUser, AppRole, int>
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
        
        public DbSet<Seller> Sellers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AspNetUsers"); // Ensuring it maps to AspNetUsers
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.ProfilePictureUrl)
                      .HasMaxLength(200)
                      .HasDefaultValue("/images/DefaultPfp.jpg");
            });
            

            
            modelBuilder.Entity<Product>()
            .Property(g => g.Price)
            .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Discount)  // Specify precision and scale for DiscountPrice
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .Property(gs => gs.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrderDetail>()
                .Property(gsd => gsd.UnitPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Discount)  // Specify precision and scale for Discount
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete


            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            // Seller - Avoid cascading delete
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Seller)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
            // AppUser - No cascading delete on user
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // No action on delete for user

            modelBuilder.Entity<ShippingAddress>()
                .HasOne(sa => sa.User)
                .WithMany(u => u.ShippingAddresses)
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Seller>()
                .HasOne(s => s.User)  // Link Seller to AppUser
                .WithMany()           // No need to define collection in AppUser
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Delete seller when user is deleted
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Seller)   // Link Product to Seller
                .WithMany(s => s.Products)  // A Seller has many products
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Seller>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Insert Parent Categories First
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Clothing",
                    ParentCategoryId = null,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 2,
                    Name = "Accessories",
                    ParentCategoryId = null,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );


            // Insert Child Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 3,
                    Name = "Men's Clothing",
                    ParentCategoryId = 1, // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 4,
                    Name = "Women's Clothing",
                    ParentCategoryId = 1, // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 5,
                    Name = "Shoes",
                    ParentCategoryId = 2, // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 6,
                    Name = "Watches",
                    ParentCategoryId = 2, // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );


            // Seed data for Brand entity
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Nike",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 2,
                    Name = "Adidas",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 3,
                    Name = "Puma",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 4,
                    Name = "Reebok",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 5,
                    Name = "Under Armour",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );


            // Seed data for CardInfo entity
            modelBuilder.Entity<CardInfo>().HasData(
                new CardInfo
                {
                    Id = 1,
                    MaskedCardNumber = "**** **** **** 1234",
                    CardholderName = "John Doe",
                    ExpirationDate = "12/25",
                    UserId = 1, // Link to existing user
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new CardInfo
                {
                    Id = 2,
                    MaskedCardNumber = "**** **** **** 5678",
                    CardholderName = "Jane Doe",
                    ExpirationDate = "11/24",
                    UserId = 2, // Link to existing user
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );


            
            // Seed data for Seller entity
            modelBuilder.Entity<Seller>().HasData(
                new Seller
                {
                    Id = 1,  // Seller ID
                    Name = "FashionHub",
                    UserId = 1,  // Link to existing user (AppUser)
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Seller
                {
                    Id = 2,  // Another Seller ID
                    Name = "StyleDepot",
                    UserId = 2,  // Link to another existing user (AppUser)
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );

            

            // Seed data for ShippingAddress entity
            modelBuilder.Entity<ShippingAddress>().HasData(
                new ShippingAddress
                {
                    Id = 1,  // ShippingAddress ID
                    UserId = 1,  // Link to existing user (AppUser)
                    AddressLine = "123 Fashion Street",
                    District = "Fashion District",
                    City = "New York",
                    PostalCode = "10001",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ShippingAddress
                {
                    Id = 2,  // Another ShippingAddress ID
                    UserId = 2,  // Link to another existing user (AppUser)
                    AddressLine = "456 Style Avenue",
                    District = "Luxury District",
                    City = "Los Angeles",
                    PostalCode = "90001",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            
            // Seed data for AppUser entity
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,  // User ID
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "johndoe",
                    Email = "john.doe@example.com",
                    Gender = "Male",
                    ProfilePictureUrl = null,
                    NormalizedUserName = "JOHNDOE",
                    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password123!"),  // Default password
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new AppUser
                {
                    Id = 2,  // Another User ID
                    FirstName = "Jane",
                    LastName = "Doe",
                    UserName = "janedoe",
                    Email = "jane.doe@example.com",
                    Gender = "Female",
                    ProfilePictureUrl = null,
                    NormalizedUserName = "JANEDOE",
                    NormalizedEmail = "JANE.DOE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password123!"),  // Default password
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            
            
            
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
