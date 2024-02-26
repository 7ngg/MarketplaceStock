namespace StockDataLayer.Models
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
