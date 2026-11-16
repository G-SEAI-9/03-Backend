namespace EncapsulationExercise.Models;

public class Thermometer
{
    // Jeder darf die Temperatur lesen, aber nur die Klasse selbst darf sie ändern.
    // Ein eigenes Feld brauchen wir nicht: Das legt der Compiler für uns an.
    public double TemperatureCelsius { get; private set; } = 20.0;

    public void SetTemperature(double value)
    {
        // Ungültige Werte lassen wir gar nicht erst rein
        if (value < -50 || value > 100)
        {
            Console.WriteLine($"{value} °C ist ungültig. Erlaubt sind -50 bis 100 °C.");
            return;
        }

        TemperatureCelsius = value;
    }

    public double GetFahrenheit()
    {
        return TemperatureCelsius * 9 / 5 + 32;
    }
}
