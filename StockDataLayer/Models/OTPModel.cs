namespace StockDataLayer.Models
{
    public class OTPModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }

        public string UserEmail { get; set; }
    }
}
