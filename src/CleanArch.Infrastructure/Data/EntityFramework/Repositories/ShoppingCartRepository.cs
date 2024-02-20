using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Infrastructure.Data.EntityFramework.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly EcommDbContext dbContext;

    public ShoppingCartRepository(EcommDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ShoppingCart GetByCustomer(Guid customerId)
    {
        return dbContext.ShoppingCarts
            .FirstOrDefault(x => x.CustomerId == customerId);
    }

    public ShoppingCart Save(ShoppingCart shoppingCart)
    {
        if (shoppingCart.Id == 0)
        {
            dbContext.Add(shoppingCart);
        }
        else
        {
            dbContext.Attach(shoppingCart);
        }
        
        dbContext.SaveChanges();

        return shoppingCart;
    }
}
