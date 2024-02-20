using CleanArch.Domain.Entities;

namespace CleanArch.Application.Interfaces;

public interface IUserResolverService
{
    User Current();
}