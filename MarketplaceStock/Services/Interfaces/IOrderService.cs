using StockDataLayer.Models;

namespace MarketplaceStock.Services.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(int userId, List<Product> orderProducts);
    }
}
