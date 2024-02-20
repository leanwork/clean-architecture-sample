using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class GetShoppingCart : IGetShoppingCart
{
    private readonly IShoppingCartRepository shoppingCartRepository;
    private readonly IUserResolverService userResolverService;

    public GetShoppingCart(IShoppingCartRepository shoppingCartRepository,
        IUserResolverService userResolverService)
    {
        this.shoppingCartRepository = shoppingCartRepository;
        this.userResolverService = userResolverService;
    }

    public ShoppingCartResponseDTO GetCurrent()
    {
        Guid customerId = userResolverService.Current().Id;

        var shoppingCart = shoppingCartRepository
            .GetByCustomer(customerId);

        var shoppingCartDto = new ShoppingCartResponseDTO();

        // map to DTO

        return shoppingCartDto;
    }
}
