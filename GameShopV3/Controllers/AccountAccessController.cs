using Microsoft.AspNetCore.Mvc;

namespace GameShopV3.Controllers
{
    public class AccountAccessController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }       

        public IActionResult LogIn()
        {
            return View();
        }
    }
}
