namespace EncapsulationExercise.Models;

public class Student
{
    // Nur get: Der Name wird einmal im Constructor gesetzt und ändert sich danach nie mehr.
    public string Name { get; }

    // private set: Die Note ändert sich, aber nur über UpdateGrade.
    public int Grade { get; private set; }

    public Student(string name)
    {
        Name = name;
    }

    public void UpdateGrade(int newGrade)
    {
        if (newGrade < 0 || newGrade > 100)
        {
            Console.WriteLine($"{newGrade} ist keine gültige Note. Erlaubt sind 0 bis 100.");
            return;
        }

        Grade = newGrade;
    }

    public void Introduce()
    {
        Console.WriteLine($"Hallo, ich bin {Name} und meine Note ist {Grade}.");
    }
}
