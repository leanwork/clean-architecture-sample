using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface IShoppingCartRepository
{
    ShoppingCart Save(ShoppingCart shoppingCart);
    ShoppingCart GetByCustomer(Guid customerId);
}
