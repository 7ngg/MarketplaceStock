using Microsoft.AspNetCore.Identity;

namespace MarketplaceStock.Models
{
    public class JWTModel
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}