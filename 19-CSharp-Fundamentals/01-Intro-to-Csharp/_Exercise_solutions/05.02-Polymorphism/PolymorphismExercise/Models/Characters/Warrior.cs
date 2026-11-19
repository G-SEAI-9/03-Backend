namespace PolymorphismExercise.Models.Characters;

public class Warrior : GameCharacter
{
    public Warrior(string name, int level)
        : base(name, level) { }

    public override void UseSpecial()
    {
        Console.WriteLine($"{Name} setzt Shield Bash ein!");
    }

    public override void Describe()
    {
        // Erst die Zeile aus GameCharacter, dann die eigene Ergänzung
        base.Describe();
        Console.WriteLine("  Rolle: kämpft vorne im Nahkampf");
    }
}
