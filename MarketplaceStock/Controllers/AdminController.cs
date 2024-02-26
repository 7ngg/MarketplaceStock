using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;

namespace MarketplaceStock.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly MarketplaceStockContext _context;

        [ActivatorUtilitiesConstructor]
        public AdminController(MarketplaceStockContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(_context.Users);
        }

        public void Save(string selectedUser, string newUsername, string newPassword, string newEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == selectedUser);

            user.Username = newUsername;
            user.Password = newPassword;
            user.Email = newEmail;

            _context.SaveChanges();
        }

        public void Remove(string selectedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == selectedUser);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
