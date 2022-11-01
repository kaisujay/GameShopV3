using GameShopV3.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV3.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _gameRepository.GetGamesAllAsync();
            return View(res);
        }
    }
}
