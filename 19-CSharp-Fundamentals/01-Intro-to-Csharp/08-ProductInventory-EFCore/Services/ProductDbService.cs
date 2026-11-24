using Infrastructure;
using Models;

namespace Services;

class ProductDbService : IProductInventoryService
{
    // field
    private readonly ProductInventoryContext _context;

    // Constructor
    public ProductDbService(ProductInventoryContext context)
    {
        _context = context;
    }

    // Properties
    public IReadOnlyCollection<Product> Products => _context.Products.ToList().AsReadOnly();

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Add(IEnumerable<Product> products)
    {
        _context.Products.AddRange(products);
        _context.SaveChanges();
    }

    public Product? FindByName(string name)
    {
        return _context.Products.FirstOrDefault(p => p.Name == name);
    }

    public Product? GetById(Guid id)
    {
        return _context.Products.Find(id);
    }

    public bool Remove(Guid id)
    {
        var product = _context.Products.Find(id);
        if (product is null)
            return false;

        _context.Products.Remove(product);
        _context.SaveChanges();
        return true;
    }
}
