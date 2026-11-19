namespace PolymorphismExercise.Models.Characters;

public class GameCharacter
{
    public string Name { get; }
    public int Level { get; }

    public GameCharacter(string name, int level)
    {
        Name = name;
        Level = level;
    }

    // * virtual: Es gibt eine allgemeine Aktion. Jede abgeleitete Klasse darf sie mit override ersetzen.
    public virtual void UseSpecial()
    {
        Console.WriteLine($"{Name} macht einen einfachen Angriff.");
    }

    public virtual void Describe()
    {
        Console.WriteLine($"{Name} (Level {Level})");
    }
}
