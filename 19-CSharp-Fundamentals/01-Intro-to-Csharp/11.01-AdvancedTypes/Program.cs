using System.Text.Json;
using System.Text.Json.Serialization;

DayOfWeek today = DayOfWeek.Wednesday;

if (today == DayOfWeek.Wednesday)
{
    Console.WriteLine($"Today is Wednesday");
}

switch (today)
{
    case DayOfWeek.Friday:
        Console.WriteLine($"It's Friday");
        break;
    default:
        Console.WriteLine($"Not Friday yet.");
        break;
}

Console.WriteLine($"{OrderStatus.Paid}");

// Enum to int, and int to enum, with a cast
int number = (int)OrderStatus.Pending;
Console.WriteLine(number); // 1

OrderStatus fromNumber = (OrderStatus)2;
Console.WriteLine(fromNumber); // Paid

// String to enum
OrderStatus parsed = Enum.Parse<OrderStatus>("Delivered");
Console.WriteLine(parsed); // Delivered

// Safer: TryParse returns false instead of throwing
if (Enum.TryParse("pending", ignoreCase: true, out OrderStatus fromInput))
{
    Console.WriteLine(fromInput); // Pending
}

if (Enum.TryParse("42", ignoreCase: true, out OrderStatus status) && Enum.IsDefined(value: status))
{ }

Console.WriteLine("\nJSON");

var options = new JsonSerializerOptions();
options.Converters.Add(new JsonStringEnumConverter());

Console.WriteLine(JsonSerializer.Serialize(OrderStatus.Paid, options));

// * 3 Stufen bei Structs:
// 1. struct                 → Value Type, mutierbar, kein == (nur .Equals)
// 2. record struct          → Value Type, mutierbar, mit ==
// 3. readonly record struct → Value Type, unveränderbar, mit == und `with`

// Enums ständig
// Structs selten, lieber direkt mit `readonly record struct`

Point p1 = new() { X = 5, Y = 10 };
Point p2 = new() { X = 5, Y = 10 };
p1.X = 25;

var p3 = p1; // echte Kopie → ändere ich p1, ändert sich p3 nicht

// Console.WriteLine($"{p1 == p2}");
Console.WriteLine($"{p1.Equals(p2)}");

Console.WriteLine("\nRecord Struct");
var pR1 = new PointRecord(5, 10);
var pR2 = new PointRecord(5, 10);
pR1.X = 10;
Console.WriteLine(value: $"{pR1 == pR2}");

Console.WriteLine("\nReadonly Record Struct");
var s1 = new Size(100, 200);
var s2 = new Size(100, 200);

// * width  in JS: Spread-Operator - const s3 = { ...s1, width: 150 }
var s3 = s1 with
{
    Width = 150,
}; // creates a new Size, s1 remains unchanged
Console.WriteLine(s1.Width); // 100
Console.WriteLine(s3.Width); // 150

var a = new Box([1, 2]); // Stack: a.Items → zeigt auf Liste [1, 2] im Heap
var b = a; // Shallow Copy: b.Items → zeigt auf DIESELBE Liste im Heap

b.Items.Add(3); // Liste im Heap wird zu [1, 2, 3]
Console.WriteLine($"a: {a.Items.Count}, b: {b.Items.Count}");

// const arr = [1, 2];
// arr.push(3);

// Faustformel:
// In Structs nur Value Types oder unveränderliche Reference Types wie `string` packen - keine mutierbaren Klassen wie `List<t>`

enum DayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}

// [JsonConverter(typeof(JsonStringEnumConverter<OrderStatus>))]
enum OrderStatus
{
    Pending = 1,
    Paid = 2,
    Shipped = 3,
    Delivered = 4,
}

// type Status = "pending" | "paid" // Union Types in TS, statt enums. In C#, gerne enums verwenden

struct Point
{
    public int X;
    public int Y;
}

public record struct PointRecord(int X, int Y);

public readonly record struct Size(int Width, int Height);

public readonly record struct Box(List<int> Items);


// Records, hauptsächlich für DTOS
// Input (Registrierung): Email + Passwort
// Output (API-Antwort): Id + Email (ohne Passwort!)

// * Entscheidungs-Spickzettel:
// Feste Auswahl (Status, Wochentage)      → enum
// Winziger, fester Wert (2–3 Felder)      → readonly record struct  (Stack)
// Reine Daten / DTOs (mehr Felder)        → record                  (Heap, unveränderbar, ==)
// Lebendiges Objekt mit State & Methoden  → class                   (Heap, veränderbar)
