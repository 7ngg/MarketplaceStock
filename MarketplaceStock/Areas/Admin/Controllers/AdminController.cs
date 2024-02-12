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

        [Area("Admin")]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View("~/Areas/Admin/Views/Index.cshtml", users);
        }
    }
}
