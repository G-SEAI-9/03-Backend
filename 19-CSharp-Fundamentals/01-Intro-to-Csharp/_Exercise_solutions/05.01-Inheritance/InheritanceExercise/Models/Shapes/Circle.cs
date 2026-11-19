namespace InheritanceExercise.Models.Shapes;

public class Circle : Shape
{
    // ! new versteckt Shape.Draw() nur. Über eine Shape-Referenz läuft weiter die Version aus Shape.
    public new void Draw()
    {
        Console.WriteLine("Circle: zeichnet einen Kreis");
    }
}
