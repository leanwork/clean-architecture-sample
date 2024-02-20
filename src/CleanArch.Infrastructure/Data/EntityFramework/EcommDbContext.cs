using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Data.EntityFramework;

public class EcommDbContext : DbContext
{
    public EcommDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Product> Products { get; set; }
}
