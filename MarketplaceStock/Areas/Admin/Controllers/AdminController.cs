using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public MarketplaceStockContext Context;

        [ActivatorUtilitiesConstructor]
        public AdminController(MarketplaceStockContext context)
        {
            Context = context;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Index.cshtml", this);
        }

        public void Save(string newUsername, string newPassword, string newEmail)
        {
            
        }
    }
}
