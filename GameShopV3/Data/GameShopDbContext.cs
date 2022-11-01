using GameShopV3.Application;
using GameShopV3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameShopV3.Data
{
    public class GameShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base (options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
