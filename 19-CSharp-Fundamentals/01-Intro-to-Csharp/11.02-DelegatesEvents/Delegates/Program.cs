// * Ziel:
// calc.Compute(4, 3, MathService.Add)      → 7
// calc.Compute(4, 3, MathService.Multiply) → 12

// # Delegates, Func and Action
var calc = new Calculator();
Console.WriteLine($"{calc.Compute(4, 3, MathService.Add)}");
Console.WriteLine($"{calc.Compute(4, 3, MathService.Multiply)}");
Console.WriteLine($"{calc.Compute(3, 3, (a, b) => a - b)}");

// const halfOff = (p: number) => { return p / 2 };
Func<decimal, decimal> halfOff = p => p / 2;
Func<decimal, decimal> addTax = p => p * 1.2m;
Func<decimal, decimal> noDiscount = p => p;
Func<decimal, decimal> iDontLikeYourPrice = p => p * 2.5m;

var engine = new PriceEngine();

Console.WriteLine(engine.CalculatePrice(100, halfOff)); // 50
Console.WriteLine(engine.CalculatePrice(100, addTax)); // 120.0
Console.WriteLine(engine.CalculatePrice(100, noDiscount)); // 100
Console.WriteLine(engine.CalculatePrice(100, iDontLikeYourPrice)); // 250.0

// products = [Keyboard (49.99), Mouse (19.99), Monitor (189.00)]
// Filter(products, isCheap)                     → Keyboard, Mouse
// Filter(products, p => p.Name.StartsWith('M')) → Mouse, Monitor

// # Typen: Delegates
// public delegate int Operation(int x, int y);

// .Where(...)  // JS: .filter()

// * Func<Eingabe1, Eingabe2, ..., Rückgabe>
//   └─ vordere Typen = input      └─ letzter Typ = immer Rückgabe
//   Beispiel: Func<string, int>      → string rein, int raus (z. B. Textlänge)
//   Beispiel: Func<int, int, bool>   → zwei ints rein, bool raus (z. B. a > b)
//   Beispiel: Func<int, int, int>    → zwei ints rein, int raus (wie unser Operation)

var products = new List<Product>
{
    new("Keyboard", 49.99m),
    new("Mouse", 19.99m),
    new("Monitor", 189.00m),
};

Func<Product, bool> isCheap = p => p.Price < 50m;

static List<Product> Filter(List<Product> items, Func<Product, bool> predicate)
{
    var result = new List<Product>();

    foreach (var item in items)
    {
        if (predicate(item))
        {
            result.Add(item);
        }
    }
    return result;
}

foreach (var product in Filter(products, isCheap))
{
    Console.WriteLine(product.Name); // Keyboard, Mouse
}

Console.WriteLine($"\nStarts with M");

foreach (var product in Filter(products, p => p.Name.StartsWith('M')))
{
    Console.WriteLine(product.Name); // Mouse, Monitor
}

// * Func<T, TResult> → rechnet etwas aus und GIBT ETWAS ZURÜCK (letzter Typ = Rückgabe)
// * Action<T>        → gibt NICHTS zurück (void), sondern TUT nur etwas (Side Effect)

var processor = new Processor();

// Log to console
processor.Process(msg => Console.WriteLine($"Console: {msg}"));

// Log to file
processor.Process(msg => File.AppendAllText("log.txt", msg + "\n"));

// * Method Groups
var messages = new List<string>();

Action<string> print = Console.WriteLine; // same as msg => Console.WriteLine(msg)
Action<string> collect = messages.Add; // same as msg => messages.Add(msg)

print("Hello");
collect("first");
collect("second");

Console.WriteLine(messages.Count); // 2

class Calculator
{
    public int Compute(int a, int b, Func<int, int, int> operation)
    {
        return operation(a, b);
    }
}

class MathService
{
    public static int Add(int a, int b) => a + b;

    public static int Multiply(int a, int b) => a * b;
}

class PriceEngine
{
    public decimal CalculatePrice(decimal basePrice, Func<decimal, decimal> strategy)
    {
        return strategy(basePrice);
    }
}

record Product(string Name, decimal Price);

class Processor
{
    public void Process(Action<string> logAction)
    {
        logAction("Processing started");
        // ... do some work ...
        logAction("Processing finished");
    }
}
