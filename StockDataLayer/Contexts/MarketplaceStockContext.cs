using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockDataLayer.Models;

namespace StockDataLayer.Contexts
{
    public class MarketplaceStockContext : DbContext
    {
        public MarketplaceStockContext() { }
        public MarketplaceStockContext(DbContextOptions<MarketplaceStockContext> opts) : base(opts) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("app-settings.json").Build();
            var connectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User{
                Id = 1,
                Username = "admin",
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin"),
                Email = "stock_admin@gmail.com",
                Role = UserRole.Admin
            });
            modelBuilder.Entity<User>(user => 
            {
                user.HasKey(e => e.Id);
                user
                    .Property(u => u.Username)
                    .HasColumnName("Username")
                    .IsRequired()
                    .HasMaxLength(16);
                user
                    .Property(u => u.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                user
                    .Property(u => u.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(50);
                user
                    .HasMany(u => u.Orders)
                    .WithOne(p => p.Owner)
                    .HasForeignKey(o => o.UserId)
                    .IsRequired();
                user
                    .Property(u => u.Role)
                    .HasColumnName("Role")
                    .HasDefaultValue(UserRole.User)
                    .IsRequired();
            });

            modelBuilder.Entity<Order>(order => {
                order.HasKey(o => o.Id);
                order
                    .Property(o => o.Date)
                    .HasColumnName("Date")
                    .IsRequired();
                order
                    .Property(o => o.Status)
                    .HasColumnName("Status")
                    .HasDefaultValue(OrderStatus.OrderPlaced)
                    .IsRequired();
            });
        
            modelBuilder.Entity<Product>().HasData(
                new Product() {
                    Name = "Product 1", 
                    Image = "https://i.imgur.com/LvKZW4A.png",
                    Price = 100.0
                },
                new Product() {
                    Name = "Product 2",
                    Image = "https://i.imgur.com/lHDLsU4.png",
                    Price = 200.0
                },
                new Product() {
                    Name = "Product 3",
                    Image = "https://i.imgur.com/174MybH.png",
                    Price = 300.0
                },
                new Product() {
                    Name = "Product 4",
                    Image = "https://i.imgur.com/NXYAbHe.png",
                    Price = 400.0
                }
            );
            modelBuilder.Entity<Product>(product => 
            {
                product.HasKey(p => p.Id);
                product
                    .Property(p => p.Name)
                    .HasColumnName("Name")
                    .IsRequired(); 
                product
                    .Property(p => p.Image)
                    .HasColumnName("Image URL");
                product
                    .Property(p => p.Price)
                    .HasColumnName("Price")
                    .IsRequired();
            });
        }
    }
}
