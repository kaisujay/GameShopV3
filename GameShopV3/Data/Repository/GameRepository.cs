using GameShopV3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShopV3.Data.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GameShopDbContext _shopDbContext;

        public GameRepository(GameShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<IEnumerable<Game>> GetGamesAllAsync()
        {
            var res = await _shopDbContext.Games.ToListAsync();
            return res;
        }

        public async Task<IEnumerable<Game>> GetGamesByNameAsync(string value)
        {
            var res = await _shopDbContext.Games
                .Where(x => x.Name.Contains(value))
                .ToListAsync();
            return res;
        }

        public async Task<Game> GetGamesByIdAsync(int value)
        {
            var res = await _shopDbContext.Games.Where(x => x.Id == value).FirstOrDefaultAsync();
            return res;
        }
    }
}
