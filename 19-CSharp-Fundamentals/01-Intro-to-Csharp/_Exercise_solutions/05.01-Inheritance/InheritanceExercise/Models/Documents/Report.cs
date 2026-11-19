namespace InheritanceExercise.Models.Documents;

public class Report : Document
{
    // Title erbt Report von Document, Author kommt neu dazu
    public string Author { get; }

    // : base(title) gibt den Titel an den Constructor von Document weiter
    public Report(string title, string author)
        : base(title)
    {
        Author = author;
    }

    public override void PrintInfo()
    {
        // Erst läuft die Version aus Document, dann ergänzt Report seine eigene Zeile
        base.PrintInfo();
        Console.WriteLine($"  Verfasst von: {Author}");
    }
}
