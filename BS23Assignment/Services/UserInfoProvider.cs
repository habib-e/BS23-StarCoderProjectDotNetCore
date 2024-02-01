using System.Security.Claims;

namespace BS23Assignment.Services
{
    public static class UserInfoProvider
    {
        public static string? GetUserName(HttpContext httpContext)
        {
            return httpContext.User.Identity?.Name
                ?? httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }

        public static string? GetUserRole(HttpContext httpContext)
        {
            return httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        }
    }
}
