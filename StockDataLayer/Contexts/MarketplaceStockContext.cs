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
        // public DbSet<OrderStatus> Statuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("app-settings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("Step");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}