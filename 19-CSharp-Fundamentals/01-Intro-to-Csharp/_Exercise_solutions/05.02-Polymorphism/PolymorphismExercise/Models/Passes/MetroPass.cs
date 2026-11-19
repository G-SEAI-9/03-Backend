namespace PolymorphismExercise.Models.Passes;

public class MetroPass : AccessPass
{
    // Für wie viele Tarifzonen der Pass gekauft wurde
    public int Zones { get; }

    public MetroPass(string holder, int zones)
        : base(holder)
    {
        Zones = zones;
    }

    public override bool Validate()
    {
        // Den allgemeinen Schritt aus AccessPass übernehmen.
        // Sein true brauchen wir nicht, ob der Pass gilt, entscheidet unsere Regel darunter.
        base.Validate();
        Console.WriteLine($"  Metro: {Zones} Zonen gekauft");
        return Zones >= 1;
    }
}
