namespace PolymorphismExercise.Models.Exporters;

public class HtmlExporter : Exporter
{
    public HtmlExporter(string fileName)
        : base(fileName) { }

    public override void Export(string content)
    {
        PrintStart("HTML");
        Console.WriteLine($"  <p>{content}</p>");
    }
}
