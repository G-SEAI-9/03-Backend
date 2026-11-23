public class BasketItem
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class ShoppingBasket
{
    // * Field readonly: wir können das Field nicht neu zuweisen = keine neue Liste (Liste, bleibt aber mutierbar)
    private readonly List<BasketItem> _items = [];

    // * Property IReadOnlyCollection: wer die Collection bekommt, kann sie mutieren
    public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

    // * Method
    public void AddItem(BasketItem item)
    {
        // business rules here
        _items.Add(item);
    }
}
