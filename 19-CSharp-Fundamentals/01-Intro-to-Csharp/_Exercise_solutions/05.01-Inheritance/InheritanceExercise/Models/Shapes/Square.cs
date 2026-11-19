namespace InheritanceExercise.Models.Shapes;

public class Square : Shape
{
    // * override ersetzt Shape.Draw(). Auch über eine Shape-Referenz läuft diese Version.
    public override void Draw()
    {
        Console.WriteLine("Square: zeichnet ein Quadrat");
    }
}
