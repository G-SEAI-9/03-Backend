namespace PolymorphismExercise.Models.Passes;

public class AccessPass
{
    public string Holder { get; }

    public AccessPass(string holder)
    {
        Holder = holder;
    }

    // * virtual: Der allgemeine Prüfschritt steht hier, die eigentliche Regel liefern die abgeleiteten Klassen.
    public virtual bool Validate()
    {
        Console.WriteLine($"Prüfe den Pass von {Holder} ...");
        return true;
    }
}
