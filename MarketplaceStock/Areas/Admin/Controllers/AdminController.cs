using Microsoft.AspNetCore.Mvc;

namespace MarketplaceStock.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Index.cshtml");
        }
    }
}