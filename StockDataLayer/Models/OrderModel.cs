namespace StockDataLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; }
        public int StatusId { get; set; }
        public OrderStatus Status { get; }

        public Order ()
        {
            Date = DateTime.Now;
            Status = OrderStatus.OrderPlaced;
        }
    }
}