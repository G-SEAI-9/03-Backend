namespace PolymorphismExercise.Models.Passes;

public class FerryPass : AccessPass
{
    // DateOnly: nur ein Datum, ohne Uhrzeit
    public DateOnly Expiry { get; }

    public FerryPass(string holder, DateOnly expiry)
        : base(holder)
    {
        Expiry = expiry;
    }

    // * sealed override: Klassen, die von FerryPass erben, dürfen Validate nicht noch einmal überschreiben.
    public sealed override bool Validate()
    {
        base.Validate();
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        bool stillValid = today <= Expiry;
        string state = stillValid ? "noch nicht abgelaufen" : "abgelaufen";
        Console.WriteLine($"  Fähre: {state}");
        return stillValid;
    }
}
