using GameShopV3.Models;
using GameShopV3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShopV3.Data.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly GameShopDbContext _shopDbContext;

        public CartRepository(GameShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<IEnumerable<CartViewModel>> ReadCartAsync(string playerId)
        {
            var res = await _shopDbContext.Carts
                .Join(_shopDbContext.Games,
                x => x.GameId,
                y => y.Id,
                (x, y) =>
                new
                {
                    PlayerId = x.PlayerId,
                    GameId = y.Id,
                    GameName = y.Name,
                    GamePrice = y.Price
                }).Where(x => x.PlayerId == playerId)
                .Join(_shopDbContext.Players,
                z => z.PlayerId,
                a => a.Id,
                (z, a) =>
                new CartViewModel
                {
                    PlayerId = z.PlayerId,
                    PlayerEmail = a.Email,
                    GameId = z.GameId,
                    GameName = z.GameName,
                    GamePrice = z.GamePrice
                }).ToListAsync();

            return res;
        }

        public async Task CreateCartAsync(string playerId, int gameId)
        {
            var cart = new CartModel()
            {
                PlayerId = playerId,
                GameId = gameId
            };

            _shopDbContext.Carts.Add(cart);
            await _shopDbContext.SaveChangesAsync();
        }

        public async Task EmptyCartAsync(string playerId)
        {
            var res = _shopDbContext.Carts
                .Where(x => x.PlayerId == playerId);

            _shopDbContext.Carts.RemoveRange(res);
            await _shopDbContext.SaveChangesAsync();
        }
    }
}
