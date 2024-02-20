namespace CleanArch.Application.DTOs;

public record ShoppingCartResponseDTO
{
    public decimal Total { get; set; }
    public IEnumerable<ShoppingCartItemResponseDTO> Items { get; set; }
}

public record ShoppingCartItemResponseDTO
{
    public string? Sku { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
