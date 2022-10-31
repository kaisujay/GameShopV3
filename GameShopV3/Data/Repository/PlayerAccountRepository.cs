using GameShopV3.Application;
using GameShopV3.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace GameShopV3.Data.Repository
{
    public class PlayerAccountRepository : IPlayerAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerAccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
    }
}
