using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Infrastructure.Data.EntityFramework.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly EcommDbContext dbContext;

    public CatalogRepository(EcommDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Product GetProductBySku(string sku)
    {
        return dbContext.Products
            .FirstOrDefault(p => p.Sku == sku);
    }
}
