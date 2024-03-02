using MarketplaceStock.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using StockDataLayer.Contexts;
using StockDataLayer.Models;

namespace MarketplaceStock.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly MarketplaceStockContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IUserManagerService _userManager;

        public AuthorizationController(MarketplaceStockContext context, ITokenService tokenService, IConfiguration configuration, IUserManagerService userManager)
        {
            _context = context;
            _tokenService = tokenService;
            _configuration = configuration;
            _userManager = userManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
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
            var token = _tokenService.CreateToken(user);

            user.Token = token;
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
                    _context.Users.Add(new User {
                            Username = username,
                            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password),
                            Email = email
                        });
                    _context.SaveChanges();
                    return RedirectToPage("/SignIn");
                }
            }

            return View();
        }

        public IActionResult SignOut()
        {
            return RedirectToAction("SignIn");
        }
    }
}
