namespace Shop.Models;

public class Product
{
    public string Sku { get; }
    public string Name { get; }
    public decimal Price { get; }

    // * Der Konstruktor prüft alle Eingaben sofort: Ungültige Produkte entstehen gar nicht erst.
    public Product(string sku, string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(sku))
        {
            throw new ArgumentException("SKU is required.", nameof(sku));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required.", nameof(name));
        }

        // ! Reihenfolge der Argumente: ArgumentException(message, paramName), aber ArgumentOutOfRangeException(paramName, message).
        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(price),
                "Price must be greater than zero."
            );
        }

        Sku = sku;
        Name = name;
        Price = price;
    }
}
