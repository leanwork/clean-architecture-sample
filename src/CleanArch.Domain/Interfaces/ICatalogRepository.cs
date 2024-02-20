using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface ICatalogRepository
{
    Product GetProductBySku(string sku);
}
