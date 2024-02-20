using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CleanArch.Infrastructure.Identity;

public class IdentityUserResolverService : IUserResolverService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public IdentityUserResolverService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public User Current()
    {
        var currentUser = httpContextAccessor.HttpContext.User;
        if (currentUser?.Identity?.IsAuthenticated == true)
        {
            return new User
            {
                Id = Guid.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value),
                Name = currentUser.FindFirst(ClaimTypes.Name).Value,
                Email = currentUser.FindFirst(ClaimTypes.Email).Value
            };
        }

        return new User
        {
            Id = Guid.Parse(httpContextAccessor.HttpContext.Request.Headers["AnonimousId"]),
            Name = "Anonymous",
            Email = string.Empty
        };
    }
}
