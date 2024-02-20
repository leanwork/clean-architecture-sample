using CleanArch.Application.DTOs;
using CleanArch.Domain.Common;

namespace CleanArch.Application.Interfaces;

public interface IAddItemShoppingCart
{
    Result Add(AddShoppingCartItemRequestDTO shoppingCartItem);
}
