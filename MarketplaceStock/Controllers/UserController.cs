using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;

namespace MarketplaceStock.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private readonly MarketplaceStockContext _context;

        public UserController(MarketplaceStockContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Store() => View(_context.Products);
    }
}
