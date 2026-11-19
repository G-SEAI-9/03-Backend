namespace InheritanceExercise.Models.Documents;

public class Invoice : Document
{
    // decimal ist der Datentyp für Geldbeträge
    public decimal Amount { get; }

    public Invoice(string title, decimal amount)
        : base(title)
    {
        Amount = amount;
    }

    // Invoice ersetzt PrintInfo komplett, ohne base.PrintInfo()
    public override void PrintInfo()
    {
        Console.WriteLine($"Rechnung: {Title} über {Amount} Euro");
    }
}
