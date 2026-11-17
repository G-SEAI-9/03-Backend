namespace EncapsulationExercise.Models;

public class Door
{
    // Startet mit false, die Tür ist also am Anfang zu
    public bool IsOpen { get; private set; }

    public void Open()
    {
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
    }

    public void Status()
    {
        string state = IsOpen ? "offen" : "geschlossen";
        Console.WriteLine($"Die Tür ist {state}.");
    }
}
