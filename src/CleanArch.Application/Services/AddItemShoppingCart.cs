using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Common;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class AddItemShoppingCart : IAddItemShoppingCart
{
    private readonly IShoppingCartRepository shoppingCartRepository;
    private readonly ICatalogRepository catalogRepository;
    private readonly IUserResolverService userResolverService;

    public AddItemShoppingCart(IShoppingCartRepository shoppingCartRepository,
        ICatalogRepository catalogRepository,
        IUserResolverService userResolverService)
    {
        this.shoppingCartRepository = shoppingCartRepository;
        this.catalogRepository = catalogRepository;
        this.userResolverService = userResolverService;
    }

    public Result Add(AddShoppingCartItemRequestDTO shoppingCartItemDto)
    {
        Result result = new Result();

        Guid customerId = userResolverService.Current().Id;
        var shoppingCart = shoppingCartRepository
            .GetByCustomer(customerId);

        var product = catalogRepository.GetProductBySku(shoppingCartItemDto.Sku);
        if (product == null)
        {
            result.Errors = new List<string>(1) { "Product not found" };
            return result;
        }

        var shoppingCartItem = new ShoppingCartItem
        {
            Sku = shoppingCartItemDto.Sku,
            Name = product.Name,
            UnitPrice = product.Price,
            Quantity = shoppingCartItemDto.Quantity
        };
        shoppingCart.AddItem(shoppingCartItem);

        shoppingCartRepository.Save(shoppingCart);

        return result;
    }
}
