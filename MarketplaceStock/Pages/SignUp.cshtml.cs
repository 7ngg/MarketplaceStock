using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Pages
{
    public class SignUp : PageModel
    {
        private readonly MarketplaceStockContext _context;

        public void OnGet()
        {
        }

        public SignUp(MarketplaceStockContext context)
        {
            _context = context;
        }

        public void OnPost(string username, string password, string confirm, string email)
        {
            if (password == confirm)
            {
                var users = _context.Users;
                users.Add(new User() { Username = username, Password = password, Email = email });
                _context.SaveChanges();
            }
        }
    }
}
