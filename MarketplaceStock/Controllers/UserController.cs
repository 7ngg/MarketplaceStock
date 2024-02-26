using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

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
        public IActionResult Basket() => View();
        [HttpPost("addBtn")]
        public IActionResult AddItem(Guid id) 
        {
            var product = _context.Products.Where(p => p.Id == id).First();
            return Ok(product);
        }
    }
}
