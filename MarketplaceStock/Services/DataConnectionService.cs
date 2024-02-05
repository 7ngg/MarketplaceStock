using Microsoft.EntityFrameworkCore;

namespace MarketplaceStock.Services
{
    public class DataConnectionService(IConfigurationBuilder builder)
    {
        private readonly IConfigurationBuilder _builder = builder;
    
        public DbContextOptions<T> Configure<T>(string connectionName) where T : DbContext
        {
            _builder.AddJsonFile("app-settings.json");
            var config = _builder.Build();
            var connectionString = config.GetConnectionString(connectionName);
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }
    }
}