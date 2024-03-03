using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockDataLayer.Models;

namespace StockDataLayer.Contexts
{
    public class MarketplaceStockContext : DbContext
    {
        public MarketplaceStockContext() { }
        public MarketplaceStockContext(DbContextOptions<MarketplaceStockContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OTPModel> OTPCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("app-settings.json").Build();
            var connectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user
                    .Property(u => u.Role)
                    .HasDefaultValue(UserRole.User);
                user
                    .Property(u => u.RefreshToken)
                    .HasDefaultValue(string.Empty);
                user.HasData(
                    new User
                    {
                        Id = 1,
                        Username = "admin",
                        Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin"),
                        Email = "stock_admin@gmail.com",
                        Role = UserRole.Admin
                    });
            });

            modelBuilder.Entity<OTPModel>(otp =>
            {
                otp
                    .Property(o => o.Code)
                    .HasDefaultValue(-1);
                otp
                    .Property(o => o.Created)
                    .HasDefaultValue(DateTime.UtcNow);
                otp
                    .Property(o => o.Expires)
                    .HasDefaultValue(DateTime.UtcNow.AddMinutes(3));
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.HasData(
                    new Product()
                    {
                        Id = 1,
                        Name = "Product 1",
                        Image = "https://i.imgur.com/LvKZW4A.png",
                        Price = 100.0
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Product 2",
                        Image = "https://i.imgur.com/lHDLsU4.png",
                        Price = 200.0
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "Product 3",
                        Image = "https://i.imgur.com/174MybH.png",
                        Price = 300.0
                    },
                    new Product()
                    {
                        Id = 4,
                        Name = "Product 4",
                        Image = "https://i.imgur.com/NXYAbHe.png",
                        Price = 400.0
                    });
            });

            modelBuilder.Entity<Order>(order =>
            {
                order
                    .Property(o => o.Date)
                    .HasDefaultValue(DateTime.Now);
                order
                    .Property(o => o.Status)
                    .HasDefaultValue(OrderStatus.Placed);
            });
        }
    }
}
