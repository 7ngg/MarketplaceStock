using Microsoft.AspNetCore.Mvc;

namespace MarketplaceStock.Areas.Moderator.Controllers
{
    public class ModeratorController : Controller
    {
        [Area("Moderator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}