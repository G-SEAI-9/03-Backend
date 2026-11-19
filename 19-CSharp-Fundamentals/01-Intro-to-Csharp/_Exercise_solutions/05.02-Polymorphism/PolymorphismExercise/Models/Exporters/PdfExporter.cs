namespace PolymorphismExercise.Models.Exporters;

public class PdfExporter : Exporter
{
    public PdfExporter(string fileName)
        : base(fileName) { }

    public override void Export(string content)
    {
        PrintStart("PDF");
        Console.WriteLine($"  Seite 1: {content}");
    }
}
