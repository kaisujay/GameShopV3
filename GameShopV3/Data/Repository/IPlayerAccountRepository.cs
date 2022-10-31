using GameShopV3.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace GameShopV3.Data.Repository
{
    public interface IPlayerAccountRepository
    {
        Task<IdentityResult> CreatePlayerAsync(RegisterPlayerViewModel registerPlayer);
    }
}