using Models;

namespace Services;

interface IProductInventoryService
{
    // Property (nur Signatur, keinen Body)
    IReadOnlyCollection<Product> Products { get; }

    // Method (nur Signatur) + Method overloading (Add 2mal)
    public void Add(Product product);
    public void Add(IEnumerable<Product> products);
    public bool Remove(Guid id);
    public Product? GetById(Guid id);
    public Product? FindByName(string name);
}
