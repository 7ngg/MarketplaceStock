using Microsoft.AspNetCore.Mvc;

namespace MarketplaceStock.Areas.User.Controllers
{
    public class UserController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View("~/Areas/User/Views/Index.cshtml");
        }
    }
}