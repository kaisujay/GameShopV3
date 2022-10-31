using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameShopV3.Data
{
    public class GameShopDbContext : IdentityDbContext
    {
        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base (options)
        {

        }
    }
}
