using GameShopV3.Data;
using GameShopV3.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV3.Controllers
{
    public class CartController : Controller
    {
        private readonly IPlayerServices _playerServices;
        private readonly ICartRepository _cartRepository;

        public CartController(IPlayerServices playerServices, ICartRepository cartRepository)
        {
            _playerServices = playerServices;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _cartRepository.ReadCartAsync(_playerServices.GetUserId());
            return View(res);
        }
        
        public async Task<IActionResult> AddingToCart(int GameId)
        {
            var playerId = _playerServices.GetUserId();
            if(playerId == null)
            {
                return RedirectToAction("Index","LogIn");
            }

            await _cartRepository.CreateCartAsync(playerId, GameId);
           
            return RedirectToAction("Index", "Game");
        }
    }
}
