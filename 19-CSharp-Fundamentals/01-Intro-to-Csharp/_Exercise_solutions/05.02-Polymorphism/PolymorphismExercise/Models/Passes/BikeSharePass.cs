namespace PolymorphismExercise.Models.Passes;

public class BikeSharePass : AccessPass
{
    public int RemainingMinutes { get; }

    public BikeSharePass(string holder, int remainingMinutes)
        : base(holder)
    {
        RemainingMinutes = remainingMinutes;
    }

    public override bool Validate()
    {
        base.Validate();
        Console.WriteLine($"  Bike-Sharing: noch {RemainingMinutes} Minuten");
        return RemainingMinutes > 0;
    }
}
