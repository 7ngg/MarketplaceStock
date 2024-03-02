namespace StockDataLayer.Models
{
    public class Product
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];
    }
}
