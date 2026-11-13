using BookLibrary;

// while (true)
// {
//     Console.WriteLine($"Tell me something:");
//     string? userInput = Console.ReadLine();
//     Console.WriteLine($"{userInput}");

//     if (userInput != null && userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
//     {
//         Console.WriteLine($"Bye");
//         return;
//     }
// }

// * List<T>
// List<int> numbers = new();
// numbers.Add(5);
// numbers.Add(10);
// List<int> numbers = [5, 10];
// numbers.Remove(5);
// numbers.Remove(3);

// foreach (int num in numbers)
// {
//     Console.WriteLine($"{num}");
// }

List<Person> persons = [];
persons.Add(new Person("Karl"));
persons.Add(new Person("Anna"));

foreach (var person in persons)
{
    Console.WriteLine($"{person.Name} {person.Id}");
}

// var found = persons.Find(p => p.Name == "Karl");
var found = persons.Find(p => string.Equals(p.Name, "karl", StringComparison.OrdinalIgnoreCase));
Console.WriteLine($"{found?.Name} {found?.Id}");
