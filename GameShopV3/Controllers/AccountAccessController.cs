using GameShopV3.Data.Repository;
using GameShopV3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameShopV3.Controllers
{
    public class AccountAccessController : Controller
    {
        private readonly IPlayerAccountRepository _playerAccountRepository;

        public AccountAccessController(IPlayerAccountRepository playerAccountRepository)
        {
            _playerAccountRepository = playerAccountRepository;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterPlayerViewModel registerPlayer)
        {
            if (ModelState.IsValid)
            {
                var res = await _playerAccountRepository.CreatePlayerAsync(registerPlayer);
                if (!res.Succeeded)
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(registerPlayer);
                }
                ModelState.Clear();
                return View();
            }
            return View(registerPlayer);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInPlayerViewModel logInPlayer)
        {
            if(ModelState.IsValid)
            {
                var res = await _playerAccountRepository.LogInPlayerAsync(logInPlayer);
                if(res.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");

            }
            return View(logInPlayer);
        }

        public async Task<IActionResult> LogOut()
        {
            await _playerAccountRepository.LogOutPlayerAsync();
            return RedirectToAction("Index","Home");            
        }
    }
}
