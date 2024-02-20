using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces;

public interface IGetShoppingCart
{
    ShoppingCartResponseDTO GetCurrent();
}
