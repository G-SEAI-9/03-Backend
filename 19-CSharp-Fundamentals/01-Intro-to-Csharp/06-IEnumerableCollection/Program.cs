InvoiceService service = new();

var lines = new List<InvoiceLine>
{
    new() { UnitPrice = 10.0m, Quantity = 2 },
    new() { UnitPrice = 5.0m, Quantity = 5 },
};

decimal total = service.CalculateTotal(lines);
Console.WriteLine($"Total: {total}");

// InvoiceLine[] moreLines = [new() { UnitPrice = 2.5m, Quantity = 4 }];
// Console.WriteLine($"Total: {service.CalculateTotal(moreLines)}");

ShoppingBasket basket = new();

basket.AddItem(
    new BasketItem
    {
        ProductId = Guid.NewGuid(),
        ProductName = "Apple",
        Price = 0.5m,
        Quantity = 3,
    }
);
basket.AddItem(
    new BasketItem
    {
        ProductId = Guid.NewGuid(),
        ProductName = "Banana",
        Price = 0.2m,
        Quantity = 5,
    }
);

foreach (var item in basket.Items)
{
    Console.WriteLine($"{item.ProductName} - {item.Quantity}");
}

// basket.Items.Add(new BasketItem());
// var first = basket.Items[0];

// ICourseCatalog catalog = new CourseDB();
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
ICourseCatalog catalog = new CourseCatalog();
Console.WriteLine($"Courses: {catalog.ListCourse().Count}");

// # IEnumerable - IList

static IEnumerable<int> GenerateNumbersLazy(int count)
{
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"[Lazy] Generating {i}");
        yield return i; // generated on demand
    }
}

var lazy = GenerateNumbersLazy(10);

foreach (var x in lazy.Take(3))
{
    Console.WriteLine($"Using {x}");
}

static List<int> GenerateNumbersEager(int count)
{
    var list = new List<int>();
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"[Eager] Generating {i}");
        list.Add(i); // everything computed right now
    }
    return list;
}

var eager = GenerateNumbersEager(10);

foreach (var x in eager.Take(3))
{
    Console.WriteLine($"Using {x}");
}
