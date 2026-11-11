// # datatypes

// # numbers
// default: int & double
// Bei Geld: decimal
// long selten und BigInteger, wenn selbst long nicht reicht

// * int - 4 Bytes / 32 Bit
using System.ComponentModel.DataAnnotations;
using System.Numerics;

int count = 12;
Console.WriteLine($"{default(int)}");
Console.WriteLine($"{sizeof(int)}");
Console.WriteLine($"Max int: {int.MaxValue:N0}");
Console.WriteLine($"Min int: {int.MinValue:N0}");

// * unit - 4 Bytes / 32 Bit, gehen aber nur ins positive

// * long - 8 Bytes / 64 Bit
long worldPopulation = 12030020200;

// var worldPopulationDemo = 12030020200;
// var myAge = 43M;
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
