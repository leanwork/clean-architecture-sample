using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data.EntityFramework;
using CleanArch.Infrastructure.Data.EntityFramework.Repositories;
using CleanArch.Infrastructure.Identity;
using CleanArch.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<EcommDbContext>(x =>
            x.UseInMemoryDatabase("ecommerce_clean_arch"));

        services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
        services.AddTransient<ICatalogRepository, CatalogRepository>();

        services.AddTransient<IUserResolverService, IdentityUserResolverService>();

        services.AddTransient<IFileUpload, AzureBlobFileUpload>();

        return services;
    }
}
