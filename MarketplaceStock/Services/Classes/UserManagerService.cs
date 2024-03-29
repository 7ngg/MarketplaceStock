using MarketplaceStock.Services.Intefaces;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Services.Classes
{
    public class UserManagerService : IUserManagerService
    {
        private readonly MarketplaceStockContext _context;

        public UserManagerService(MarketplaceStockContext context)
        {
            _context = context;
        }

        public bool CheckPassword(string username, string password)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, _context.Users.FirstOrDefault(u => u.Username == username).Password);

        public string FindUsername(string username)
            => _context.Users.FirstOrDefault(u => u.Username == username).Username;

        public User GetUser(int id) => _context.Users.FirstOrDefault(u => u.Id == id);
    }
}