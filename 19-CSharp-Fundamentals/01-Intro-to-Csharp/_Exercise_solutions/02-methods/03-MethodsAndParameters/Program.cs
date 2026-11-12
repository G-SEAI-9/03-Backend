// Namespaces und Dateistruktur
using Utils;

// Calculator-Grundlagen
Console.WriteLine($"Add(2, 3): {Calculator.Add(2, 3)}");
Console.WriteLine($"Multiply(3, 4): {Calculator.Multiply(3, 4)}");

// Überladen und Rückgabetypen
Console.WriteLine($"Add(2.5, 3.5): {Calculator.Add(2.5, 3.5)}");
Console.WriteLine($"Divide(10, 4): {Calculator.Divide(10, 4)}");
Console.WriteLine($"Divide(10, 0): {Calculator.Divide(10, 0)}");
Console.WriteLine($"Average(4, 6): {Statistics.Average(4, 6)}");
Console.WriteLine($"Average(4, 6, 8): {Statistics.Average(4, 6, 8)}");

// Formatter mit mehreren Überladungen
Console.WriteLine(Formatter.FormatNumber(7));
Console.WriteLine(Formatter.FormatNumber(2.5));

// Standard- und benannte Parameter
Console.WriteLine(Formatter.FormatMessage("Hi"));
Console.WriteLine(Formatter.FormatMessage("Hi", repeat: 3));
