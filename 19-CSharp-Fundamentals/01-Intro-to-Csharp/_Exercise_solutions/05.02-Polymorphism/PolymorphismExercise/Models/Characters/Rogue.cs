namespace PolymorphismExercise.Models.Characters;

// Extra challenge: Rogue kommt dazu, ohne dass sich die Schleife in Program.cs ändert
public class Rogue : GameCharacter
{
    public Rogue(string name, int level)
        : base(name, level) { }

    public override void UseSpecial()
    {
        Console.WriteLine($"{Name} setzt Shadow Strike ein!");
    }

    // ! new statt override: Über eine GameCharacter-Referenz läuft weiter GameCharacter.Describe().
    public new void Describe()
    {
        base.Describe();
        Console.WriteLine("  Rolle: schleicht durch die Schatten");
    }
}
