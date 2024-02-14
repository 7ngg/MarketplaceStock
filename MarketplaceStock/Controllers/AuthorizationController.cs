using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Controllers
{
    public class AuthorizationController : Controller
    {
        private MarketplaceStockContext _context;

        public AuthorizationController(MarketplaceStockContext context)
        {
            _context = context;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            User user = _context.Users.Where(u => u.Username == username).FirstOrDefault();
            if (BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
            {
                return RedirectToAction("Index", $"{user.Role}");
            }

            return RedirectToPage("/SignIn");
        }

        [HttpPost]
        public IActionResult SignUp(string username, string password, string confirm, string email)
        {
            if (ModelState.IsValid)
            {
                if (confirm == password)
                {
                    _context.Users.Add(new User { Username = username, Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password), Email = email });
                    _context.SaveChanges();
                    return RedirectToPage("/SignIn");
                }
            }

            return View();
        }

        public IActionResult SignOut()
        {
            return RedirectToAction("SignIn");
        }
    }
}
