using Microsoft.EntityFrameworkCore;

namespace MarketplaceStock.Services.Intefaces
{
    public interface IDataConnectionService
    {
        public DbContextOptions<T> Configure<T>(string connectionName) where T : DbContext;
    }
}