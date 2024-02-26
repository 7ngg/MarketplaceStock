using StockDataLayer.Models;

namespace MarketplaceStock.Services.Intefaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}