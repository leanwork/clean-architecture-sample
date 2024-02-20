namespace CleanArch.Application.DTOs;

public record AddShoppingCartItemRequestDTO
{
    public string Sku { get; set; }
    public int Quantity { get; set; }
}
