using Entity.Entities;
using Entity.Enums;
using Entity.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
                .Property(p => p.DiscountPrice)  // Specify precision and scale for DiscountPrice
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
                    Id = Guid.Parse("9f8c60a4-2f7b-4d90-9b87-5649ec3b8c70"),
                    Name = "Clothing",
                    ParentCategoryId = null, // Correct: Use ParentCategoryId, not ParentCategory
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("06e22d0d-8397-45d4-843e-fb19b2c96065"),
                    Name = "Accessories",
                    ParentCategoryId = null, // Correct: Use ParentCategoryId
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );

            // Insert Child Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("bfb03f41-489f-45e6-846e-bcb179b4a47e"),
                    Name = "Men's Clothing",
                    ParentCategoryId = Guid.Parse("9f8c60a4-2f7b-4d90-9b87-5649ec3b8c70"), // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("289ca2fa-b0a7-41a0-8f4f-8032bc1a7b26"),
                    Name = "Women's Clothing",
                    ParentCategoryId = Guid.Parse("9f8c60a4-2f7b-4d90-9b87-5649ec3b8c70"), // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("50e15df5-f894-4c0f-a192-2e1ed0c39269"),
                    Name = "Shoes",
                    ParentCategoryId = Guid.Parse("06e22d0d-8397-45d4-843e-fb19b2c96065"), // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("24d11d3a-c3c7-46f6-83e1-84346b7b2788"),
                    Name = "Watches",
                    ParentCategoryId = Guid.Parse("06e22d0d-8397-45d4-843e-fb19b2c96065"), // Correct
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for Brand entity
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = Guid.Parse("1b6c5b5e-4dff-4b91-a3be-3543b739073d"),
                    Name = "Nike",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = Guid.Parse("9a2d2958-d7f4-40f4-a3c2-1be6bcdb12b2"),
                    Name = "Adidas",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = Guid.Parse("3c17450d-4127-41bc-b191-9589fa52b158"),
                    Name = "Puma",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = Guid.Parse("4de8c7a8-6cf9-4f33-a301-4dc9b9d91a8d"),
                    Name = "Reebok",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = Guid.Parse("5ec3a4e7-bf56-496a-bbbb-07d1839dcbb2"),
                    Name = "Under Armour",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for CardInfo entity
            modelBuilder.Entity<CardInfo>().HasData(
                new CardInfo
                {
                    Id = Guid.Parse("6c2f8c9e-6f85-4f24-86f3-2bf4ed8c5f0c"),
                    MaskedCardNumber = "**** **** **** 1234",
                    CardholderName = "John Doe",
                    ExpirationDate = "12/25",
                    UserId = Guid.Parse("19f2f710-6f7d-4d1b-ae4d-89b267f2bc58"), // Link to existing user
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new CardInfo
                {
                    Id = Guid.Parse("f4c60c97-f2c8-4bb3-a6e4-7ebf441ed120"),
                    MaskedCardNumber = "**** **** **** 5678",
                    CardholderName = "Jane Doe",
                    ExpirationDate = "11/24",
                    UserId = Guid.Parse("22a2b9a6-0b36-4a43-bb3d-d2ff7769c5e8"), // Link to existing user
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for Order entity
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.Parse("5c8d5cfa-32d4-4e42-8c3b-3dbd8472bb6b"),  // Order ID
                    UserId = Guid.Parse("19f2f710-6f7d-4d1b-ae4d-89b267f2bc58"),  // Link to existing user
                    TotalQuantity = 3,
                    TotalPrice = 150.50m,
                    IsDiscountApplied = true,
                    IsFullyrefunded = false,
                    ShippingAddressId = Guid.Parse("4ecae589-2b3d-42b9-bd29-2d826ec6f0d0"),  // Link to existing shipping address
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Order
                {
                    Id = Guid.Parse("bb07ad85-046c-48a5-b23c-cbd74f16e1de"),  // Another Order ID
                    UserId = Guid.Parse("22a2b9a6-0b36-4a43-bb3d-d2ff7769c5e8"),  // Link to another user
                    TotalQuantity = 5,
                    TotalPrice = 220.99m,
                    IsDiscountApplied = false,
                    IsFullyrefunded = false,
                    ShippingAddressId = Guid.Parse("e0ae1b63-2b1f-4e5e-bcf5-b5dfba9f9411"),  // Link to another shipping address
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for OrderDetail entity
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = Guid.Parse("6e83c73c-fd0b-4b79-9829-e4c758f481a1"),  // OrderDetail ID
                    OrderId = Guid.Parse("5c8d5cfa-32d4-4e42-8c3b-3dbd8472bb6b"),  // Link to existing order
                    ProductId = Guid.Parse("b1a1be3f-8901-4f69-9b5b-5f6bde5b6e2a"),  // Link to existing product
                    UnitPrice = 50.17m,
                    Discount = 5.00m,
                    IsRefunded = false,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderDetail
                {
                    Id = Guid.Parse("b673b5f7-7868-4c1b-a172-5a7393a2c3bb"),  // Another OrderDetail ID
                    OrderId = Guid.Parse("bb07ad85-046c-48a5-b23c-cbd74f16e1de"),  // Link to another order
                    ProductId = Guid.Parse("2d17280e-4c32-4bfa-8d94-978d33bc5b56"),  // Link to another product
                    UnitPrice = 75.99m,
                    Discount = 0.00m,
                    IsRefunded = false,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for Seller entity
            modelBuilder.Entity<Seller>().HasData(
                new Seller
                {
                    Id = Guid.Parse("c8a75b8a-6fbe-4672-b9a7-59bb1f7d5d99"),  // Seller ID
                    Name = "FashionHub",
                    UserId = Guid.Parse("19f2f710-6f7d-4d1b-ae4d-89b267f2bc58"),  // Link to existing user (AppUser)
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Seller
                {
                    Id = Guid.Parse("d70f1b24-d8e8-45f8-a6d7-b1d4552c78cf"),  // Another Seller ID
                    Name = "StyleDepot",
                    UserId = Guid.Parse("22a2b9a6-0b36-4a43-bb3d-d2ff7769c5e8"),  // Link to another existing user (AppUser)
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for ShippingAddress entity
            modelBuilder.Entity<ShippingAddress>().HasData(
                new ShippingAddress
                {
                    Id = Guid.Parse("4ecae589-2b3d-42b9-bd29-2d826ec6f0d0"),  // ShippingAddress ID
                    UserId = Guid.Parse("19f2f710-6f7d-4d1b-ae4d-89b267f2bc58"),  // Link to existing user (AppUser)
                    AddressLine = "123 Fashion Street",
                    District = "Fashion District",
                    City = "New York",
                    PostalCode = "10001",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ShippingAddress
                {
                    Id = Guid.Parse("e0ae1b63-2b1f-4e5e-bcf5-b5dfba9f9411"),  // Another ShippingAddress ID
                    UserId = Guid.Parse("22a2b9a6-0b36-4a43-bb3d-d2ff7769c5e8"),  // Link to another existing user (AppUser)
                    AddressLine = "456 Style Avenue",
                    District = "Luxury District",
                    City = "Los Angeles",
                    PostalCode = "90001",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for Size entity
            modelBuilder.Entity<Size>().HasData(
                new Size
                {
                    Id = Guid.Parse("cf2c9b63-eada-4fcb-92e5-18f8fc8a1ebf"),  // Size ID
                    Name = "Small",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Size
                {
                    Id = Guid.Parse("f53b3e79-cbed-43f9-a1ab-370e92a1b1fe"),  // Another Size ID
                    Name = "Medium",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Size
                {
                    Id = Guid.Parse("c4d2bdae-bc97-42f4-8a29-72f063bb004c"),  // Another Size ID
                    Name = "Large",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Size
                {
                    Id = Guid.Parse("5b95ec43-42e2-4f8e-b2d6-e1f8e5a5c25e"),  // Another Size ID
                    Name = "Extra Large",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for AppUser entity
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = Guid.Parse("19f2f710-6f7d-4d1b-ae4d-89b267f2bc58"),  // User ID
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "johndoe",
                    Email = "john.doe@example.com",
                    Gender = Gender.Male,
                    ProfilePictureUrl = null,
                    NormalizedUserName = "JOHNDOE",
                    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password123!"),  // Default password
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new AppUser
                {
                    Id = Guid.Parse("22a2b9a6-0b36-4a43-bb3d-d2ff7769c5e8"),  // Another User ID
                    FirstName = "Jane",
                    LastName = "Doe",
                    UserName = "janedoe",
                    Email = "jane.doe@example.com",
                    Gender = Gender.Female,
                    ProfilePictureUrl = null,
                    NormalizedUserName = "JANEDOE",
                    NormalizedEmail = "JANE.DOE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password123!"),  // Default password
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );
            // Seed data for Product entity
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("b1a1be3f-8901-4f69-9b5b-5f6bde5b6e2a"),  // Product ID
                    Name = "Men's Running Shoes",
                    Description = "Lightweight running shoes for men.",
                    Price = 75.00m,
                    DiscountPrice = 65.00m,
                    StockQuantity = 50,
                    Condition = "New",
                    Gender = Gender.Male,
                    AgeGroup = AgeGroup.Adult,
                    CategoryId = Guid.Parse("9f8c60a4-2f7b-4d90-9b87-5649ec3b8c70"),  // Link to "Clothing" category
                    BrandId = Guid.Parse("1b6c5b5e-4dff-4b91-a3be-3543b739073d"),  // Link to "Nike" brand
                    SizeId = Guid.Parse("cf2c9b63-eada-4fcb-92e5-18f8fc8a1ebf"),  // Link to "Small" size
                    Color = "Blue",
                    PrimaryImageUrl = "/images/products/mens-running-shoes.jpg",
                    SellerId = Guid.Parse("c8a75b8a-6fbe-4672-b9a7-59bb1f7d5d99"),  // Link to existing seller
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Product
                {
                    Id = Guid.Parse("2d17280e-4c32-4bfa-8d94-978d33bc5b56"),  // Another Product ID
                    Name = "Women's Jacket",
                    Description = "Stylish and warm jacket for women.",
                    Price = 120.00m,
                    DiscountPrice = 100.00m,
                    StockQuantity = 30,
                    Condition = "New",
                    Gender = Gender.Female,
                    AgeGroup = AgeGroup.Adult,
                    CategoryId = Guid.Parse("289ca2fa-b0a7-41a0-8f4f-8032bc1a7b26"),  // Link to "Women's Clothing" category
                    BrandId = Guid.Parse("9a2d2958-d7f4-40f4-a3c2-1be6bcdb12b2"),  // Link to "Adidas" brand
                    SizeId = Guid.Parse("f53b3e79-cbed-43f9-a1ab-370e92a1b1fe"),  // Link to "Medium" size
                    Color = "Black",
                    PrimaryImageUrl = "/images/products/womens-jacket.jpg",
                    SellerId = Guid.Parse("d70f1b24-d8e8-45f8-a6d7-b1d4552c78cf"),  // Link to another existing seller
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            // Seed data for Review entity
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = Guid.Parse("f8e3e0bb-08b6-4b26-a773-3ff542cf0078"),  // Review ID
                    ProductId = Guid.Parse("b1a1be3f-8901-4f69-9b5b-5f6bde5b6e2a"),  // Link to existing product
                    UserId = Guid.Parse("19f2f710-6f7d-4d1b-ae4d-89b267f2bc58"),  // Link to existing user (John Doe)
                    SellerId = Guid.Parse("c8a75b8a-6fbe-4672-b9a7-59bb1f7d5d99"),  // Link to existing seller (FashionHub)
                    Rating = 5,
                    Comment = "Excellent quality and fast shipping!",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Review
                {
                    Id = Guid.Parse("d113a2b7-48d9-48f2-9e18-5582d5b07b82"),  // Another Review ID
                    ProductId = Guid.Parse("2d17280e-4c32-4bfa-8d94-978d33bc5b56"),  // Link to another existing product
                    UserId = Guid.Parse("22a2b9a6-0b36-4a43-bb3d-d2ff7769c5e8"),  // Link to another existing user (Jane Doe)
                    SellerId = Guid.Parse("d70f1b24-d8e8-45f8-a6d7-b1d4552c78cf"),  // Link to another existing seller (StyleDepot)
                    Rating = 4,
                    Comment = "Great product, but the delivery took longer than expected.",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
