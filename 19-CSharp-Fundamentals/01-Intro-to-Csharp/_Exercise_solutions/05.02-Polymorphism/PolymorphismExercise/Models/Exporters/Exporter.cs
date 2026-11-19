namespace PolymorphismExercise.Models.Exporters;

// * abstract: Von Exporter selbst gibt es keine Objekte. Wer direkt von Exporter erbt, muss Export überschreiben.
public abstract class Exporter
{
    public string FileName { get; }

    // protected: Nur abgeleitete Klassen rufen diesen Constructor auf, über : base(fileName)
    protected Exporter(string fileName)
    {
        FileName = fileName;
    }

    // Kein Body: Wie exportiert wird, weiß erst die abgeleitete Klasse
    public abstract void Export(string content);

    // protected: Die abgeleiteten Klassen dürfen diese Hilfsmethode benutzen, Program.cs nicht
    protected void PrintStart(string format)
    {
        Console.WriteLine($"[{format}] Exportiere nach {FileName} ...");
    }
}
