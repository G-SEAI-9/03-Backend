using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

// DateOnly.TryParse("01-10-2026", out var parsedDate);
// Console.WriteLine($"Year: {parsedDate.Year}, Month: {parsedDate.Month}, Day: {parsedDate.Day}");

if (
    DateOnly.TryParseExact(
        "01-10-2026",
        format: "dd-MM-yyyy",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out DateOnly parsedDate
    )
)
{
    Console.WriteLine($"Year: {parsedDate.Year}, Month: {parsedDate.Month}, Day: {parsedDate.Day}");
}
else
{
    Console.WriteLine($"Invald date format");
}

// # File Class
// * File.Exists()
// Console.WriteLine($"{File.Exists("test.txt")}");

// File.WriteAllText("example.txt", "Hello, World");
// File.AppendAllText("example.txt", "Salut!");
// File.WriteAllLines("example.txt", ["a", "b", "c", "d"]);

// Console.WriteLine($"{File.ReadAllText("example.txt")}");
// string[] content = File.ReadAllLines("example.txt");
// foreach (var line in content)
// {
//     Console.WriteLine($"{line}");
// }
// byte[] bytes = File.ReadAllBytes("example.txt");
// foreach (var b in bytes)
// {
//     Console.WriteLine($"{b}");
// }

// * File.Copy(sourceFileName, destinatin);
// * File.Move(sourceFileName, destinatin);
// File.Delete("example.txt");

// # FileInfo
// var fileInfo = new FileInfo("example.txt");

// Console.WriteLine($"{fileInfo.Length}");
// Console.WriteLine($"{fileInfo.DirectoryName}");
// fileInfo.Delete();

// # Directory
// Console.WriteLine($"{Directory.Exists("data")}");
// Ensure directory exists
// if (!Directory.Exists("data"))
// {
//     Directory.CreateDirectory("data");
// }

//  "data/" + "example.json"
// UNIX (macOS, Linux, BSD) `/`
// Windows `\`

// # Path
// var path = Path.Combine("data", "example.json");

// Console.WriteLine($"{path}");
// Console.WriteLine($"{Path.GetDirectoryName(path)}");
// Console.WriteLine($"{Path.GetExtension(path)}");
// Console.WriteLine($"{Path.GetRandomFileName()}");
// Console.WriteLine($"{Path.GetTempFileName()}");

// Write line by line with a StreamWriter
// using var writer = new StreamWriter("log.txt", append: true);
// writer.WriteLine($"Log entry at {DateTime.Now}");

// Read line by line with a StreamReader
// using var reader = new StreamReader("log.txt");

// string? line;
// while ((line = reader.ReadLine()) != null)
// {
//     Console.WriteLine(line);
// }

// # JSON
// JSON.stringify(obj) // obj → JSON-String
// JSON.parse(json) // JSON-String → obj
// * JsonSerializer.Serialize

var person = new Person { Name = "Aisha", Age = 30 };

var options = new JsonSerializerOptions { WriteIndented = true };

string json = JsonSerializer.Serialize(person, options);

// Console.WriteLine(json); // {"Name":"Aisha","Age":30}
File.WriteAllText("person.json", json);

string jsonIn = File.ReadAllText("person.json");
Console.WriteLine($"in: {jsonIn}");

// * JsonSerializer.Deserialize
var aisha = JsonSerializer.Deserialize<Person>(jsonIn);
Console.WriteLine($"{aisha?.Name} - {aisha?.Age} - {aisha?.Date.Month}");

var listOfPerson = new List<Person>
{
    new() { Name = "Karl", Age = 20 },
    new() { Name = "Hannah", Age = 20 },
    new() { Name = "John", Age = 20 },
};

var jsonPerson = JsonSerializer.Serialize(listOfPerson);
List<Person> loaded = JsonSerializer.Deserialize<List<Person>>(jsonPerson) ?? [];

class Person
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
}
