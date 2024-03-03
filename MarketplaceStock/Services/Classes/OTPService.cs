using System.Net.Mail;
using System.Net;
using MarketplaceStock.Services.Interfaces;
using StockDataLayer.Models;

namespace MarketplaceStock.Services.Classes
{
    public class OTPService : IOTPService
    {
        private readonly string _originEmail = "boardappmvvm@outlook.com";
        private readonly string _originPassword = "rQYqukWHAtbwVugVfFP7";

        public async Task<OTPModel> SendOTP(string email)
        {
            Random random = new();
            OTPModel otp = new()
            {
                Code = random.Next(1000, 9999),
                Created = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(3)
            };

            string subject = $"Email confirmation";
            string body = $"Your confirmation code: {otp.Code}. Time: {otp.Created} UTC";

            var smtp = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_originEmail, _originPassword)
            };

            await smtp.SendMailAsync(_originEmail, email, subject, body);

            return otp;
        }
    }
}
