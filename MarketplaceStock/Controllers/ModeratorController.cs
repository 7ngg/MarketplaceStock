using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Areas.Moderator.Controllers
{
    public class ModeratorController : Controller
    {
        private MarketplaceStockContext _context;

        public ModeratorController(MarketplaceStockContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Orders", "Moderator");
        }

        public IActionResult Orders()
        {
            var orders = _context.Orders.Include(o => o.Owner);
            return View(orders);
        }

        [HttpPost("SaveOrder")]
        public IActionResult SaveOrder(int productId, string newStatus)
        {
            var status = (OrderStatus)Enum.Parse(typeof(OrderStatus), newStatus);
            var order = _context.Orders.First(p => p.Id == productId);

            if (status - order.Status != 1)
            {
                return BadRequest("Invalid operation");
            }

            order.Status = status;
            _context.SaveChanges();

            return RedirectToAction("Orders", "Moderator");
        }
    }
}