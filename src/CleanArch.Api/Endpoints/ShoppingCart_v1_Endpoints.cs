using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;

namespace CleanArch.Api.Endpoints;

public static class ShoppingCart_v1_Endpoints
{
    public static void MapShoppingCart_v1_Endpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppingcart", GetShoppingCart)
            .WithName("Get_ShoppingCart_v1")
            .WithOpenApi();

        app.MapPost("api/v1/shoppingcart/item", AddShoppingCartItem)
            .WithName("Post_ShoppingCart_v1")
            .WithOpenApi();
    }

    public static async Task<IResult> GetShoppingCart(IGetShoppingCart getShoppingCart)
    {
        return Results.Ok(getShoppingCart.GetCurrent());
    }

    public static async Task<IResult> AddShoppingCartItem(AddShoppingCartItemRequestDTO request,
        IAddItemShoppingCart addItemShoppingCart)
    {
        var result = addItemShoppingCart.Add(request);
        return result.Success ? Results.Ok() : Results.BadRequest(result.Errors.First());
    }
}
