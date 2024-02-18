using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;

namespace MarketplaceStock.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly MarketplaceStockContext _context;

        public UsersController(MarketplaceStockContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<StockDataLayer.Models.User>> GetUser()
        {
            return _context.Users.ToList();
        }
    }
}