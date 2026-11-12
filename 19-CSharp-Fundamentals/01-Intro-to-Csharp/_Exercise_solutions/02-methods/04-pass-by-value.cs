using System.Globalization;

// * Pass by Value
int number = 5;
Console.WriteLine($"Vor Bump: {number}");
ValueDemo.Bump(number);
Console.WriteLine($"Nach Bump: {number}");

// * Pass by Reference mit ref
int first = 1;
int second = 2;
Console.WriteLine($"Vor Swap: first = {first}, second = {second}");
RefOps.Swap(ref first, ref second);
Console.WriteLine($"Nach Swap: first = {first}, second = {second}");

// * Eine Klasseninstanz übergeben
// Beide Methoden bekommen eine Kopie der Referenz. Deposit folgt ihr zum selben Objekt und ändert dieses Objekt.
// Reset lässt nur seine eigene Kopie auf ein neues Objekt zeigen, davon bekommt der account des Aufrufers nichts mit.

var account = new Account();
account.Balance = 100m;

// var account = new Account { Balance = 100m };

Console.WriteLine($"Vor Deposit: {account.Balance}");
AccountOps.Deposit(account, 50m);
Console.WriteLine($"Nach Deposit: {account.Balance}");
Console.WriteLine($"Vor Reset: {account.Balance}");
AccountOps.Reset(account);
Console.WriteLine($"Nach Reset: {account.Balance}");

// * Mehrere Ergebnisse mit out
bool isValid = Parser.TryParsePrice("12.50", out decimal price);
Console.WriteLine($"12.50: {isValid}, Preis: {price}");
isValid = Parser.TryParsePrice("£12.50", out price);
Console.WriteLine($"£12.50: {isValid}, Preis: {price}");
isValid = Parser.TryParsePrice("12,50", out price);
Console.WriteLine($"12,50: {isValid}, Preis: {price}");
isValid = Parser.TryParsePrice("oops", out price);
Console.WriteLine($"oops: {isValid}, Preis: {price}");

// * Read-only-Referenz mit in
var comfortable = new TemperatureRange(18, 24);
Console.WriteLine($"Enthält 18: {RangeChecker.Contains(in comfortable, 18)}");
Console.WriteLine($"Enthält 21: {RangeChecker.Contains(in comfortable, 21)}");
Console.WriteLine($"Enthält 24: {RangeChecker.Contains(in comfortable, 24)}");
Console.WriteLine($"Enthält 30: {RangeChecker.Contains(in comfortable, 30)}");

public class ValueDemo
{
    public static void Bump(int number)
    {
        number++;
        Console.WriteLine($"In Bump: {number}");
    }
}

public class RefOps
{
    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
        // (b, a) = (a, b);
    }
}

public class AccountOps
{
    public static void Deposit(Account account, decimal amount)
    {
        account.Balance += amount;
    }

    public static void Reset(Account account)
    {
        account = new Account();
    }
}

public class Parser
{
    public static bool TryParsePrice(string text, out decimal price)
    {
        string cleaned = text.Trim();
        cleaned = cleaned.Replace("£", "");
        cleaned = cleaned.Replace(',', '.');

        // Wenn das Parsen scheitert, setzt TryParse price auf 0, die Methode braucht für diesen Fall also keinen extra Code.
        return decimal.TryParse(cleaned, CultureInfo.InvariantCulture, out price);
    }
}

public class RangeChecker
{
    public static bool Contains(in TemperatureRange range, double value)
    {
        // Wenn wir range hier einen neuen TemperatureRange zuweisen, gibt es den Fehler CS8331, weil in range read-only macht.
        return value >= range.Min && value <= range.Max;
    }
}

public class Account
{
    // Eine Property: ein Wert, der in jedem Account-Objekt gespeichert ist und gelesen und geändert werden kann
    public decimal Balance { get; set; }
}

// Ein `struct` fasst Werte zusammen wie eine Klasse, wird aber bei der Übergabe by value kopiert (wie ein int).
// readonly bedeutet, dass sich seine Werte nicht mehr ändern können, nachdem der Konstruktor gelaufen ist.
public readonly struct TemperatureRange
{
    public double Min { get; }
    public double Max { get; }

    public TemperatureRange(double min, double max)
    {
        Min = min;
        Max = max;
    }
}
