using MarketplaceStock.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceStock.Services
{
    public class DataConnectionService : IDataConnectionService
    {
        private readonly IConfigurationBuilder _builder;

        public DataConnectionService(IConfigurationBuilder builder)
        {
            _builder = builder;
        }

        public DbContextOptions<T> Configure<T>(string connectionName) where T : DbContext
        {
            _builder.AddJsonFile("app-settings.json");
            var config = _builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseSqlServer(config.GetConnectionString(connectionName));

            return optionsBuilder.Options;
        }
    }
}