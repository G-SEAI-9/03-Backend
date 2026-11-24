using Shop.Models;

namespace Shop.Services;

public class ProductCatalogue
{
    // #pragma warning disable schaltet eine Analyzer-Warnung aus, #pragma warning restore direkt danach wieder ein.
    // MA0002 will einen StringComparer, den hatten wir noch nicht. Ohne ihn vergleicht Dictionary SKUs exakt ("ABC-123" != "abc-123"), das passt hier.
#pragma warning disable MA0002
    private readonly Dictionary<string, Product> _bySku = [];
#pragma warning restore MA0002

    // * Guard-Checks am Anfang jeder Methode halten den Normalfall danach kurz und klar.
    public void AddProduct(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product), "Product is required.");
        }

        if (_bySku.ContainsKey(product.Sku))
        {
            throw new ArgumentException(
                $"A product with SKU '{product.Sku}' already exists.",
                nameof(product)
            );
        }

        _bySku[product.Sku] = product;
    }

    public Product GetBySku(string sku)
    {
        // Leere SKU zuerst prüfen, sonst landet sie unten bei "No product with SKU" (KeyNotFoundException)
        // und bei null wirft TryGetValue eine ArgumentNullException statt ArgumentException.
        if (string.IsNullOrWhiteSpace(sku))
        {
            throw new ArgumentException("SKU is required.", nameof(sku));
        }

        // ? Warum nutzen wir TryGetValue statt einfach _bySku[sku]?
        // Mit eigener KeyNotFoundException bestimmen wir die Meldung selbst, statt die allgemeine Standardmeldung des Dictionary zu zeigen.
        if (!_bySku.TryGetValue(sku, out Product? product))
        {
            throw new KeyNotFoundException($"No product with SKU '{sku}'.");
        }

        return product;
    }
}
