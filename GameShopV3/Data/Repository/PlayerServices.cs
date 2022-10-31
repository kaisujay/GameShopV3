using System.Security.Claims;

namespace GameShopV3.Data.Repository
{
    public class PlayerServices : IPlayerServices
    {
        private readonly IHttpContextAccessor _httpContext;

        public PlayerServices(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
