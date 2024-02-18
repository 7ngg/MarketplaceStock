using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Areas.Admin.Controllers
{
    [Authorize]
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
            return View("~/Areas/Admin/Views/Index.cshtml", _context.Users);
        }

        public void Save(string newUsername, string newPassword, string newEmail)
        {
            
        }
    }
}
