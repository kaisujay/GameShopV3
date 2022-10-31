using Microsoft.AspNetCore.Identity;

namespace GameShopV3.Application
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
