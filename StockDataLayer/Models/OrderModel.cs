namespace StockDataLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; }

        #region Order Status
        public OrderStatus Status { get; }
        #endregion

        #region Owner
        public int UserId { get; init; }
        public User Owner { get; init; }
        #endregion

        #region Products
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];
        #endregion

        public Order ()
        {
            Date = DateTime.Now;
            Status = OrderStatus.OrderPlaced;
        }
    }
}