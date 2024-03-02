using MarketplaceStock.Services.Intefaces;
using MarketplaceStock.Services.Interfaces;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly MarketplaceStockContext _context;
        private readonly IUserManagerService _userManager;

        public OrderService(MarketplaceStockContext context, IUserManagerService userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void CreateOrder(int userId, List<Product> products)
        {
            var user = _userManager.GetUser(userId);

            var order = new Order()
            {
                Owner = user,
                Products = products
            };

            user.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
