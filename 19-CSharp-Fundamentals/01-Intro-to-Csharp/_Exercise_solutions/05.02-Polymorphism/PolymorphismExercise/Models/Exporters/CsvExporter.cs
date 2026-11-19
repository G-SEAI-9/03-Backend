namespace PolymorphismExercise.Models.Exporters;

public class CsvExporter : Exporter
{
    public CsvExporter(string fileName)
        : base(fileName) { }

    public override void Export(string content)
    {
        PrintStart("CSV");
        Console.WriteLine("  id;text");
        Console.WriteLine($"  1;{content}");
    }
}
