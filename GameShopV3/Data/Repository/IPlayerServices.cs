namespace GameShopV3.Data.Repository
{
    public interface IPlayerServices
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}