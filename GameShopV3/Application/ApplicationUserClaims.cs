using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace GameShopV3.Application
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaims(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager, options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UsersId", user.Id));
            identity.AddClaim(new Claim("UsersEmail", user.Email));
            identity.AddClaim(new Claim("UsersUserName", user.UserName));
            identity.AddClaim(new Claim("UsersName", user.Name));
            identity.AddClaim(new Claim("UsersDateOfBirth", user.DateOfBirth.ToString()));
            return identity;
        }
    }
}
