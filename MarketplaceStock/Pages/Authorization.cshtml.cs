using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockDataLayer.Contexts;

namespace MarketplaceStock.Pages
{
    public class AuthorizationModel : PageModel
    {
        private readonly MarketplaceStockContext _context;

        public AuthorizationModel(MarketplaceStockContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password)
        {
            var pass = _context.Users.Where(u => u.Username == username).Select(u => u.Password).FirstOrDefault();
            if (pass == password)
            {
                return RedirectToPage("/");
            }

            return RedirectToPage("/Error");
        }
    }
}
