var catalogue = new ProductCatalogue();
var processor = new PaymentProcessor();

// # Happy Path
var mug = new Product("ABC-123", "Coffee Mug", 12.50m);
catalogue.AddProduct(mug);

var order = new Order();
order.AddItem(catalogue.GetBySku("ABC-123"), 2);
Console.WriteLine($"Order total: {order.Total():0.00}");

// # Szenarien 1 bis 5: Product, ProductCatalogue und Order
// * Hier am Rand der Anwendung (Program.cs) fangen wir Exceptions ab; die Klassen selbst werfen nur.
// Jedes Szenario hat seinen eigenen try-Block, damit ein Fehler die nächsten Szenarien nicht stoppt.

// Szenario 1: leerer Produktname
try
{
    var badName = new Product("XYZ-999", "", 5m);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Product error: {ex.Message}");
}

// Szenario 2: ungültiger Preis
try
{
    var badPrice = new Product("BAD-000", "Napkin", 0m);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Product error: {ex.Message}");
}

// Szenario 3: doppelte SKU
try
{
    catalogue.AddProduct(new Product("ABC-123", "Duplicate", 1m));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Catalogue error: {ex.Message}");
}

// Szenario 4: unbekannte SKU
try
{
    var missing = catalogue.GetBySku("DOES-NOT-EXIST");
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine($"Catalogue error: {ex.Message}");
}

// Szenario 5: ungültige Menge
try
{
    order.AddItem(mug, 0);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Order error: {ex.Message}");
}

// # Szenarien 6 bis 9: Zahlungen über TryCharge
TryCharge(processor, "4444-5555-6666-7777", order.Total()); // klappt
TryCharge(processor, "0000-1111-2222-3333", order.Total()); // abgelehnt: Karte gesperrt
TryCharge(processor, "4444-5555-6666-7777", -10m); // ungültiger Betrag
TryCharge(processor, "4444-5555-6666-7777", 2500m); // abgelehnt: Betrag über dem Limit

// # Weitere Prüfungen aus der Tabelle
// Leere SKU im Product-Konstruktor
try
{
    var badSku = new Product("   ", "Tea Cup", 8m);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Product error: {ex.Message}");
}

// Leere SKU bei GetBySku
try
{
    var emptySku = catalogue.GetBySku("   ");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Catalogue error: {ex.Message}");
}

// Leere Kartennummer bei Charge
TryCharge(processor, "   ", order.Total());

// Die beiden null-Fälle verhindert schon der Compiler (CS8625, durch WarningsAsErrors ein Fehler).
// Die Guard-Checks in AddProduct und CartLine schützen trotzdem zur Laufzeit.
// catalogue.AddProduct(null);  // Fehler: null darf nicht an den non-nullable Parameter product übergeben werden
// order.AddItem(null, 1);      // Fehler: null darf nicht an den non-nullable Parameter product übergeben werden

Console.WriteLine("Done.");

// # Lokale Funktion TryCharge
// Darf am Ende der Datei stehen und oben schon aufgerufen werden, ähnlich wie function-Hoisting in JS.
static void TryCharge(PaymentProcessor processor, string cardNumber, decimal amount)
{
    try
    {
        processor.Charge(cardNumber, amount);
    }
    // ! Spezifische catch-Blöcke müssen vor catch (Exception) stehen: C# prüft von oben nach unten.
    // catch (Exception) fängt jede Exception ab, sodass catch (PaymentDeclinedException) und catch (ArgumentException) danach nie erreicht würden (Compilerfehler CS0160).
    catch (PaymentDeclinedException ex)
    {
        Console.WriteLine($"Payment declined: {ex.Reason} (Amount={ex.Amount:0.00})");
    }
    // ? Warum fängt catch (ArgumentException) auch den negativen Betrag (-10m) ab?
    // ArgumentOutOfRangeException erbt von ArgumentException, daher fängt dieser Block auch die Unterklasse.
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Bad argument: {ex.Message}");
    }
    catch (Exception ex)
    {
        // Sicherheitsnetz am Rand der Anwendung, damit ein unerwarteter Fehler das Programm nicht abstürzen lässt
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
    // catch (KeyNotFoundException) { } // Fehler: catch (Exception) fängt bereits alle Exceptions ab (CS0160)
    finally
    {
        // * finally läuft immer: egal ob try geklappt hat oder ein catch angesprungen ist.
        Console.WriteLine("End of payment attempt.");
    }
}
