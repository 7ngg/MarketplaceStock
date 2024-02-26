namespace MarketplaceStock.Services.Intefaces
{
    public interface IUserManagerService
    {
        string FindUsername(string username);
        bool CheckPassword(string username, string password);
    }
}