
using StockDataLayer.Models;

namespace MarketplaceStock.Services.Interfaces
{
    public interface IOTPService
    {
        public Task<OTPModel> SendOTP(string email);
    }
}
