namespace StockDataLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; }

        #region Order Status
        public int StatusId { get; set; }
        public OrderStatus Status { get; }
        #endregion

        #region Owner
        public int UserId { get; init; }
        public User Owner { get; init; }
        #endregion

        public Order ()
        {
            Date = DateTime.Now;
            Status = OrderStatus.OrderPlaced;
        }
    }
}