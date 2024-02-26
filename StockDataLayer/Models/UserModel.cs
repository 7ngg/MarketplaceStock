namespace StockDataLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public string Token { get; set; }
    }
}
