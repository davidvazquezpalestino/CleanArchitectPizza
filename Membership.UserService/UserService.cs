using Membership.Entities.Interfaces;

namespace Membership.UserService;
internal class UserService : IUserService
{
    readonly IHttpContextAccessor Context;
    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        Context = httpContextAccessor;
    }

    public bool IsAuthenticated =>
        Context.HttpContext.User.Identity?.IsAuthenticated ?? false;

    public string UserId =>
        Context.HttpContext.User.Identity?.Name;

    public string FullName =>
        Context.HttpContext.User.Claims
        .Where(c => c.Type == "FullName")
        .Select(c => c.Value).FirstOrDefault();     
}


