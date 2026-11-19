#!/usr/bin/env dotnet

// # Arrays: T[]
// * feste Länge & geordnet

// # List<T>
// * basieren auf arrays, flexibel zu vergrößern

// int[] scores = [1, 2, 3, 4, 5];
// scores[1] = 90;

// int thirdScore = scores[2];
// Console.WriteLine($"{thirdScore}");

// PrintArray(scores);

// int target = 90;
// int foundIndex = -1; // -1 steht für: nicht gefunden

// for (int i = 0; i < scores.Length; i++)
// {
//     if (scores[i] == target)
//     {
//         foundIndex = i;
//         break;
//     }
// }

// Console.WriteLine($"Target value at index {foundIndex}");

// void PrintArray(int[] arr)
// {
//     for (int i = 0; i < arr.Length; i++)
//     {
//         Console.WriteLine($"{arr[i]}");
//     }
// }

// # List<T>
// * basieren auf arrays, flexibel zu vergrößern & geordnet
// // List<string> inventory = new List<string> { "Helath Potion", "Iron Shield" };
// // var inventory = new List<string> { "Helath Potion", "Iron Shield" };
// List<string> inventory = ["Health Potion", "Iron Shield"];
// Console.WriteLine(inventory.ToString());

// inventory.Add("Steel Sword");
// inventory.Add("Mana Potion");
// inventory.Insert(1, "Antidote"); // Einfügen

// foreach (var item in inventory)
// {
//     Console.WriteLine($"{item}");
// }

// Console.Write($"Access by index: ");
// Console.WriteLine($"{inventory[0]}");

// bool hasShield = inventory.Contains("Iron Shield");

// int swordIndex = inventory.IndexOf("Steel Sword");
// Console.WriteLine($"{hasShield} and at {swordIndex}");

// inventory[2] = "Tower Shield"; // Überschreiben
// inventory.Remove("Health Potion");
// inventory.RemoveAt(0);

// foreach (var item in inventory)
// {
//     Console.WriteLine($"{item}");
// }

Student firstStudent = new(1, "Karl", 3.2);
Console.WriteLine(firstStudent);

GradeBookManager manager = new();

manager.AddStudent(new Student(2, "Hannah", 1.2));
manager.AddStudent(new Student(2, "Hannah", 1.2));

manager.DisplayAll();

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Grade { get; set; }

    public Student(int id, string name, double grade)
    {
        Id = id;
        Name = name;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"[ID: {Id}] Name: {Name} | Grade: {Grade}";
    }
}

class GradeBookManager
{
    private readonly List<Student> _students = [];

    public bool AddStudent(Student student)
    {
        if (student == null)
            return false;

        if (FindIndexById(student.Id) != -1)
        {
            Console.WriteLine("Student already exists");
            return false;
        }

        _students.Add(student);
        Console.WriteLine("Student added");

        return true;
    }

    public Student? GetStudentById(int id)
    {
        int index = FindIndexById(id);
        if (index == -1)
        {
            return null;
        }
        return _students[index];
    }

    private int FindIndexById(int id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }

    public void DisplayAll()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine($"No student records found");
            return;
        }
        foreach (var student in _students)
        {
            Console.WriteLine($"{student}");
        }
    }
}
