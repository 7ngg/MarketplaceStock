using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;
using StockDataLayer.Models;
using System.Net.Http.Headers;

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
            return RedirectToAction("Users", "Admin");
        }

        public IActionResult Users()
        {
            return View(_context.Users);
        }

        public IActionResult Products()
        {
            return View(_context.Products);
        }

        [HttpPost("Close")]
        public IActionResult Close() => RedirectToAction("Users");

        [HttpPost("Save")]
        public IActionResult Save(string selectedUser, string newUsername, string newPassword, string newEmail, string newRole)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == selectedUser);
            var role = (UserRole)Enum.Parse(typeof(UserRole), newRole);

            if (user.Username != newUsername) user.Username = newUsername;
            if (user.Password != newPassword) user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(newPassword);
            if (user.Email != newEmail) user.Email = newEmail;
            if (user.Role != role) user.Role = role;

            _context.SaveChanges();
            return RedirectToAction("Users", "Admin");
        }

        [HttpPost("Remove")]
        public IActionResult Remove(string selectedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == selectedUser);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Users", "Admin");
        }

        public IActionResult AddNewProduct(string productName, string productImage, int productPrice)
        {
            var product = new Product()
            {
                Name = productName,
                Image = productImage,
                Price = productPrice
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Products", "Admin");
        }
    }
}
