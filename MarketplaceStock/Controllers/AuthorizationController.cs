using MarketplaceStock.Services.Intefaces;
using MarketplaceStock.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly MarketplaceStockContext _context;
        private readonly ITokenService _tokenService;
        private readonly IUserManagerService _userManager;
        private readonly IOTPService _otpService;

        public AuthorizationController(MarketplaceStockContext context, ITokenService tokenService, IUserManagerService userManager, IOTPService otpService)
        {
            _context = context;
            _tokenService = tokenService;
            _userManager = userManager;
            _otpService = otpService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public async Task<IActionResult> EmailConfirmation()
        {
            var pendingUser = JsonConvert.DeserializeObject<User>(Request.Cookies["PendingUser"]);

            if (pendingUser == null)
            {
                return BadRequest("No pending user");
            }

            var code = await _otpService.SendOTP(pendingUser.Email);
            code.UserEmail = pendingUser.Email;

            _context.OTPCodes.Add(code);
            _context.SaveChanges();

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            var managedUser = _userManager.FindUsername(username);
            if (managedUser == null) return BadRequest("Invalid credentials");

            var isPasswordValid = _userManager.CheckPassword(managedUser, password);
            if (!isPasswordValid) return BadRequest("Invalid credentials");

            var user = _context.Users.First(u => u.Username == username);
            var token = _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            _tokenService.SetRefreshToken(user, token, refreshToken);

            _context.SaveChanges();

            Response.Cookies.Append("CurrentUserId", user.Id.ToString(), new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddMinutes(30),
            });
            return RedirectToAction("Index", $"{user.Role}");
        }

        [HttpPost]
        public IActionResult SignUp(string username, string password, string confirm, string email)
        {
            if (ModelState.IsValid)
            {
                if (confirm == password)
                {
                    var user = new User()
                    {
                        Username = username,
                        Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password),
                        Email = email
                    };
                    Response.Cookies.Append(
                        "PendingUser",
                        JsonConvert.SerializeObject(user),
                        new CookieOptions
                        {
                            Expires = DateTimeOffset.Now.AddMinutes(15)
                        });
                    return RedirectToAction("EmailConfirmation", "Authorization");
                }
            }

            return View();
        }

        public IActionResult ConfirmEmail(int code)
        {
            var pendingUser = JsonConvert.DeserializeObject<User>(Request.Cookies["PendingUser"]);
            var response = _context.OTPCodes.FirstOrDefault(o => o.UserEmail == pendingUser.Email);

            if (response == null)
            {
                return BadRequest("No valid otps. Please, retry");
            }

            if (response.Expires < DateTime.UtcNow)
            {
                return BadRequest("Code expired. Please, retry");
            }

            if (response.Code == code && response.UserEmail == pendingUser.Email)
            {
                _context.Users.Add(pendingUser);
                _context.OTPCodes.Remove(response);
                _context.SaveChanges();

                return RedirectToAction("SignIn", "Authorization");
            }

            _context.OTPCodes.Remove(response);
            _context.SaveChanges();
            
            return BadRequest("Please, try again");
        }

        public IActionResult Resend()
        {
            var pendingUser = JsonConvert.DeserializeObject<User>(Request.Cookies["PendingUser"]);
            var response = _context.OTPCodes.Where(o => o.UserEmail == pendingUser.Email).ToList();

            _context.OTPCodes.RemoveRange(response);
            _context.SaveChanges();

            return RedirectToAction("EmailConfirmation", "Authorization");
        }

        public IActionResult SignOut()
        {
            return RedirectToAction("SignIn");
        }
    }
}
