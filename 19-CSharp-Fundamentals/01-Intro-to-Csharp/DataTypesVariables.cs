using System.Globalization;
using System.Numerics;
using System.Text;

// # datatypes

// # numbers
// default: int & double
// Bei Geld: decimal
// long selten und BigInteger, wenn selbst long nicht reicht

// * int - 4 Bytes / 32 Bit

int count = 12;
Console.WriteLine($"{default(int)}");
Console.WriteLine($"{sizeof(int)}");
Console.WriteLine($"Max int: {int.MaxValue:N0}");
Console.WriteLine($"Min int: {int.MinValue:N0}");

// * unit - 4 Bytes / 32 Bit, gehen aber nur ins positive

// * long - 8 Bytes / 64 Bit
long worldPopulation = 12030020200;

// var worldPopulationDemo = 12030020200;
var myAge = 43M;

// Console.WriteLine($"Age: {myAge}");

var smallNumber = 24;
var bigNumber = 120300202220;
var commabumber = 24.5;

// double coundB = count;
// coundB = "zwölf";

Console.WriteLine($"\nLong:");
Console.WriteLine($"{default(long)}");
Console.WriteLine($"{sizeof(long)}");
Console.WriteLine($"Max long: {long.MaxValue:N0}");
Console.WriteLine($"Min long: {long.MinValue:N0}");

long max = long.MaxValue;

// Console.WriteLine($"{max + 2}");

// * BigInteger - für gigantisch große Zahlen - langsam!
BigInteger big = max;
Console.WriteLine($"{big + 2}");

// * float - 4 Bytes / 32 Bit
float price = 12.5F;
Console.WriteLine($"\nFloat:");
Console.WriteLine($"{default(float)}");
Console.WriteLine($"{sizeof(float)}");
Console.WriteLine($"Max float: {float.MaxValue:N0}");
Console.WriteLine($"Min float: {float.MinValue:N0}");

// * decimal - 16 Bytes / 128 Bit wir rechnen hier decimal und nicht binär
// Console.WriteLine($"{0.1m + 0.2m}");
// Console.WriteLine($"{0.1m + 0.2m == 0.3m}");

decimal salary = 1_000_000_000.23M;
Console.WriteLine($"\nDecimal");
Console.WriteLine($"{default(decimal)}");
Console.WriteLine($"{sizeof(decimal)}");
Console.WriteLine($"Max decimal: {decimal.MaxValue:N0}");
Console.WriteLine($"Min decimal: {decimal.MinValue:N0}");

// * double - 8 Bytes / 64 Bit
double degrees = 34.5D;
Console.WriteLine($"\nDouble");
Console.WriteLine($"{default(double)}");
Console.WriteLine($"{sizeof(double)}");
Console.WriteLine($"Max double: {double.MaxValue:N0}");
Console.WriteLine($"Min double: {double.MinValue:N0}");

Console.WriteLine($"{1234567.89F}"); // float ca. 7 Stellen
Console.WriteLine($"{1234567.89}"); // double etwa 15 oder 16 Stellen

// # Operatoren
int a = 10;
int b = 3;

Console.Write("\n");
Console.WriteLine(a + b);
Console.WriteLine(a - b);
Console.WriteLine(a * b);
Console.WriteLine(a / b);
Console.WriteLine(a % b);

Console.Write("\n");
Console.WriteLine((double)a / b);

// Console.WriteLine((double)(a / b));

Console.Write("\n");
Console.WriteLine(a > 5);
Console.WriteLine(a < 5);
Console.WriteLine(a == b);
Console.WriteLine(a != b);

// Console.WriteLine($"{"5" == 5}");

Console.Write("\n");
Console.WriteLine(a > 5 && b < 10);
Console.WriteLine(a > 5 || b < 10);
Console.WriteLine(!(a == 5));

// shorthand Operatoren
Console.WriteLine($"\ncounter");
int counter = 0;
Console.WriteLine($"{counter}");

// counter = counter + 5
counter += 5;
Console.WriteLine($"{counter}");
counter = 10;
Console.WriteLine($"{counter}");
counter /= 2;
Console.WriteLine($"{counter}");
counter++;
Console.WriteLine($"{counter}");

double score = 7.85D;
int trunctaced = (int)score;
Console.WriteLine($"{trunctaced}");

double countB = count;

var result = (double)10 / 3;
Console.WriteLine($"{result}");

try
{
    checked
    {
        int max2 = int.MaxValue;
        int boom = max2 + 1;
        Console.WriteLine($"What is happening?");
    }
}
catch (OverflowException)
{
    Console.WriteLine($"Overflow caught");
}

string status = myAge > 18 ? "go" : "don't go";
Console.WriteLine($"{status}");

// * strings
string regular = "Hello World";
char letter = 'A';

// string path = "C:\\User\\Name\\Documents";
string path = @"C:\User\Name\Documents";

string raw = """
"Hello", said the program.
        This supports multi-line
""";
Console.WriteLine($"{raw}");

// interpolation
string name = "Alice";
string interpolated = $"User: {name}";

string concat = "Hello" + name;

string phrase = "The quick brown fox jumps";
bool hasFox = phrase.Contains("fox");

int index = phrase.IndexOf("brown");
bool starts = phrase.StartsWith("The");

Console.WriteLine($"{hasFox} {index} {starts}");

string emptyText = "";
string whitespaceText = "   ";

bool checkEmpty = string.IsNullOrEmpty(whitespaceText);
bool checkBlank = string.IsNullOrWhiteSpace(whitespaceText);

Console.WriteLine($"{checkEmpty} {checkBlank}");

string input = "     C# Programming  ";

string upper = input.ToUpper(); // Alles in Großbuchstaben
string trimmed = input.Trim(); // Links und recht den Whitespace entfernen
string replaced = input.Replace("C#", ".NET");

string removed = trimmed.Remove(0, 3);

// string removed = trimmed[3..];

Console.WriteLine($"[{upper}] [{trimmed}] [{replaced}] [{removed}]");

string text = "Hello World";
string text2 = "HELLO WORLD";

int length = text.Length;

char firstChar = text[0];
string subString = text.Substring(0, 5);

// string subString = text[..5];

Console.WriteLine($"{length} {firstChar} {subString}");

string fruits = "apple,banana,orange";

// string -> array
string[] items = fruits.Split(",");

// array -> string
string combined = string.Join(" | ", items);
Console.WriteLine($"{combined}, Length: {items.Length}");

Console.WriteLine($"{text == text2}");
Console.WriteLine($"{text.Equals(text2, StringComparison.OrdinalIgnoreCase)}");

// Console.WriteLine($"{string.Compare("apfel", "Zebra", StringComparison.Ordinal) < 0}");
// Console.WriteLine($"{string.Compare("apfel", "Zebra", StringComparison.CurrentCulture) < 0}");

Console.WriteLine($"{CultureInfo.CurrentCulture.Name}");

// string[] logEntries = { "User logged in", "Updated profile", "Exported report", "User logged out" };
string[] logEntries = ["User logged in", "Updated profile", "Exported report", "User logged out"];
var sb = new StringBuilder();

string start = "";

for (int i = 0; i < logEntries.Length; i++)
{
    sb.Append($"Entry: {logEntries[i]}\n");
    start += $"Entry: {logEntries[i]}\n";
}

string finalString = sb.ToString();
Console.WriteLine($"{finalString}");

string result3 = null ?? "maybe";
Console.WriteLine($"{result3}");

object data = "Hello C#";

// Console.WriteLine($"{data.GetType()}");
// data = 42;
// Console.WriteLine($"{data.GetType()}");

// Console.WriteLine($"{data.Length}");

if (data is string message)
{
    Console.WriteLine($"{message.ToUpper()}");
}
else
{
    Console.WriteLine($"{data}");
}

// compile time datatype
// runtime data type

string userAge = "20";

// string userAge = "Hello";
bool isValid = int.TryParse(userAge, out int userAgeInt);
Console.WriteLine($"{isValid} {userAgeInt}");
