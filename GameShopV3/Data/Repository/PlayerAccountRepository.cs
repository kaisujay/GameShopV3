using GameShopV3.Application;
using GameShopV3.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace GameShopV3.Data.Repository
{
    public class PlayerAccountRepository : IPlayerAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PlayerAccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreatePlayerAsync(RegisterPlayerViewModel registerPlayer)
        {
            var user = new ApplicationUser()
            {
                Name = registerPlayer.Name,
                UserName = registerPlayer.UserName,
                Email = registerPlayer.Email,
                DateOfBirth = registerPlayer.DateOfBirth
            };

            var res = await _userManager.CreateAsync(user, registerPlayer.Password);
            return res;
        }

        public async Task<SignInResult> LogInPlayerAsync(LogInPlayerViewModel logInPlayer)
        {
            var res = await _signInManager.PasswordSignInAsync(logInPlayer.UserName, logInPlayer.Password, false, false);
            return res;
        }

        public async Task LogOutPlayerAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
