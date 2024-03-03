using MarketplaceStock.Services.Intefaces;
using MarketplaceStock.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private readonly MarketplaceStockContext _context;
        private readonly IOrderService _orderService;
        private readonly IUserManagerService _userManager;

        public UserController(MarketplaceStockContext context, IOrderService orderService, IUserManagerService userManager)
        {
            _context = context;
            _orderService = orderService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Store", "User");
        }

        public IActionResult Store() => View(_context.Products);
        public IActionResult Orders()
        {
            var userId = Convert.ToInt32(Request.Cookies["CurrentUserId"]);
            var user = _userManager.GetUser(userId);
            _context.Orders.Where(o => o.UserId == userId).Load();

            return View(user.Orders);
        }

        public IActionResult Basket()
        {
            var bag = GetFromCookies();
            return bag.Any() ? View(bag) : BadRequest("Bag is empty");
        }

        [HttpPost("addBtn")]
        public IActionResult AddItem(int id)
        {
            var product = _context.Products.First(p => p.Id == id);
            var bag = GetFromCookies();
            bag.Add(product);
            SaveToCookies(bag);
            return RedirectToAction("Store", "User");
        }

        [HttpPost("purchase-btn")]
        public IActionResult Purchase()
        {
            var userId = Convert.ToInt32(Request.Cookies["CurrentUserId"]);
            var bag = GetFromCookies();

            _orderService.CreateOrder(userId, bag);
            Response.Cookies.Delete("Bag");
            return RedirectToAction("Store", "User");
        }

        private void SaveToCookies(List<Product> bag)
        {
            string bagJson = JsonConvert.SerializeObject(bag);
            Response.Cookies.Append("Bag", bagJson, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(1)
            });
        }

        private List<Product> GetFromCookies()
        {
            string bagJson = Request.Cookies["Bag"];
            if (!string.IsNullOrEmpty(bagJson))
            {
                return JsonConvert.DeserializeObject<List<Product>>(bagJson);
            }
            return [];
        }
    }
}
