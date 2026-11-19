namespace InheritanceExercise.Models.Documents;

public class Document
{
    public string Title { get; }

    public Document(string title)
    {
        Title = title;
    }

    // * virtual: Document bringt eine eigene Version mit, abgeleitete Klassen dürfen sie mit override ersetzen.
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Dokument: {Title}");
    }
}
