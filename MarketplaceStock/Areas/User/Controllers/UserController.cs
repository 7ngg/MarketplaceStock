using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Models;

namespace MarketplaceStock.Areas.User.Controllers
{
    public class UserController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View("~/Areas/User/Views/Index.cshtml");
        }

        public IActionResult Store() => View("~/Areas/User/Views/Store.cshtml");
    }
}