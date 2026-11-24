using Shop.Models;

namespace Shop.Services;

public class CartLine
{
    public Product Product { get; }
    public int Quantity { get; }

    public CartLine(Product product, int quantity)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product), "Product is required.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be at least 1.");
        }

        Product = product;
        Quantity = quantity;
    }

    public decimal Subtotal => Product.Price * Quantity;
}

public class Order
{
    private readonly List<CartLine> _lines = new();

    public IReadOnlyCollection<CartLine> Lines => _lines.AsReadOnly();

    // * Order fängt keine Exceptions ab: Bei ungültigen Eingaben wirft CartLine, und die Exception wandert hoch bis zu Program.cs.
    public void AddItem(Product product, int quantity)
    {
        _lines.Add(new CartLine(product, quantity));
    }

    public decimal Total()
    {
        decimal sum = 0m;
        foreach (CartLine line in _lines)
        {
            sum += line.Subtotal;
        }
        return sum;
    }
}
