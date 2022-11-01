using GameShopV3.Models;

namespace GameShopV3.Data.Repository
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAllAsync();
        Task<Game> GetGamesByIdAsync(int value);
        Task<IEnumerable<Game>> GetGamesByNameAsync(string value);
    }
}