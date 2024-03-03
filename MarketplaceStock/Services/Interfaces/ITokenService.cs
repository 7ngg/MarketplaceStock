using StockDataLayer.Models;

namespace MarketplaceStock.Services.Intefaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        RefreshToken GenerateRefreshToken();
        void SetRefreshToken(User user, string token, RefreshToken refreshToken);
        string RefreshToken(User user);
    }
}