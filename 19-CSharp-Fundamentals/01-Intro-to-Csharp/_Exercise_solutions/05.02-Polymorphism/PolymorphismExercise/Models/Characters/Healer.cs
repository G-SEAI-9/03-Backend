namespace PolymorphismExercise.Models.Characters;

public class Healer : GameCharacter
{
    public Healer(string name, int level)
        : base(name, level) { }

    public override void UseSpecial()
    {
        Console.WriteLine($"{Name} setzt Group Heal ein!");
    }

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine("  Rolle: heilt die Gruppe");
    }
}
