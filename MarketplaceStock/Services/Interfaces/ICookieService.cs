namespace MarketplaceStock.Services.Intefaces
{
    public interface ICookieService
    {
        void Save<T>(T obj);
        T Retrieve<T>();
    }
}
