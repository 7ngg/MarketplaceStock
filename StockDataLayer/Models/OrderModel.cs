namespace StockDataLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        #region Order Status
        public OrderStatus Status { get; set; }
        #endregion

        #region Owner
        public int UserId { get; set; }
        public User Owner { get; set; }
        #endregion

        public ICollection<Product> Products { get; set; } = [];
    }
}