using GameShopV3.Models;
using GameShopV3.Models.ViewModels;

namespace GameShopV3.Data.Repository
{
    public interface ICartRepository
    {
        Task CreateCartAsync(string playerId, int gameId);
        Task EmptyCartAsync(string playerId);
        Task<IEnumerable<CartViewModel>> ReadCartAsync(string playerId);
    }
}