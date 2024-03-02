using StockDataLayer.Models;

namespace MarketplaceStock.Services.Intefaces
{
    public interface IUserManagerService
    {
        public User GetUser(int id);
        string FindUsername(string username);
        bool CheckPassword(string username, string password);
    }
}