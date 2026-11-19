namespace PolymorphismExercise.Models.Exporters;

// Extra challenge: MarkdownExporter kommt dazu, ohne dass sich die Schleife in Program.cs ändert
public class MarkdownExporter : Exporter
{
    public MarkdownExporter(string fileName)
        : base(fileName) { }

    public override void Export(string content)
    {
        PrintStart("Markdown");
        Console.WriteLine($"  **{content}**");
    }
}
