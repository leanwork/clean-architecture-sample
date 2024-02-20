namespace CleanArch.Domain.Entities;

public class ShoppingCart
{
    public ShoppingCart()
    {
        Items = new List<ShoppingCartItem>(0);
    }

    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public IEnumerable<ShoppingCartItem> Items { get; set; }

    public decimal Total => Items.Sum(x => x.TotalPrice);

    public void AddItem(ShoppingCartItem item)
    {
        var items = Items as List<ShoppingCartItem>;
        if (items == null)
            return;

        var existingItem = items.FirstOrDefault(x => x.Sku == item.Sku);
        if (existingItem == null)
        {
            // add
            items.Add(item);
            return;
        }

        // update
        existingItem.UnitPrice = item.UnitPrice;
        existingItem.Quantity = item.Quantity;
    }
}

public class ShoppingCartItem
{
    public string? Sku { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal TotalPrice => UnitPrice * Quantity;
}
