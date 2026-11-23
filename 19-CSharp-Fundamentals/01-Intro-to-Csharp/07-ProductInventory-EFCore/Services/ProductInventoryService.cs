using Models;

namespace Services;

class ProductInventoryService : IProductInventoryService
{
    // field (State)
    private readonly List<Product> _products = [];

    // Property
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    // Methods
    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Add(IEnumerable<Product> products)
    {
        foreach (var p in products)
        {
            _products.Add(p);
        }
    }

    public Product? FindByName(string name)
    {
        return _products.FirstOrDefault(p =>
            string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)
        );
    }

    public Product? GetById(Guid id)
    {
        // return _products.FirstOrDefault(p => p.Id == id);
        foreach (var product in _products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }
        return null;
    }

    public bool Remove(Guid id)
    {
        var product = GetById(id);
        if (product is null)
        {
            return false;
        }
        return _products.Remove(product);
    }
}
