namespace StockDataLayer.Models
{
    public enum OrderStatus
    {
        OrderPlaced = 1,
        ArrivedOnStock,
        Sent,
        InCustoms,
        Delivered
    }
}