namespace PolymorphismExercise.Models.Characters;

public class Mage : GameCharacter
{
    public Mage(string name, int level)
        : base(name, level) { }

    public override void UseSpecial()
    {
        Console.WriteLine($"{Name} setzt Arcane Burst ein!");
    }

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine("  Rolle: zaubert aus der Distanz");
    }
}
