#!/usr/bin/env dotnet

class Program
{
    public static void Main(string[] args)
    {
        // double estimatedLightYears = 14.5;
        // double fuelNeeded = CalculateJumpFuel(estimatedLightYears, 5000);
        // Console.WriteLine($"Fuel required: {fuelNeeded}");

        // FireLaser(80);
        // FireLaser(100, isStunMode: false);

        // PlotCourse("Nebula-9");
        // PlotCourse(214.5, -45.2, 89.1);
        // bool isHabitable = ScanPlanet("Kelper-186f", out string stegosaurus);
        // Console.WriteLine(isHabitable);
        // Console.WriteLine(stegosaurus);

        // int lifeSupportPower = 100;
        // Console.WriteLine($"inital: {lifeSupportPower}");
        // SustainDamage(ref lifeSupportPower);
        // Console.WriteLine($"after Damage: {lifeSupportPower}");

        Person.DoSomething();
    }

    // private ist in Klassen default
    private static double CalculateJumpFuel(double lightYears, int shipMass)
    {
        double baseFuel = lightYears * 1.5;
        double massPenalty = shipMass * 0.02;
        return baseFuel + massPenalty;
    }

    private static void FireLaser(int powerLevel, bool isStunMode = true)
    {
        if (isStunMode)
        {
            Console.WriteLine($"Firing EMP burst at {powerLevel}");
        }
        else
        {
            Console.WriteLine($"Warning! Firing laser at {powerLevel}");
        }
    }

    private static void PlotCourse(string destinationName)
    {
        Console.WriteLine($"Course plotted to known location: {destinationName}");
    }

    private static void PlotCourse(double x, double y, double z)
    {
        Console.WriteLine($"Calculating coordinates: X: {x}, Y: {y}, Z: {z}");
    }

    // static void PlotCourse(string hello)
    // {
    //     Console.WriteLine($"{hello}");
    // }

    //     static void PlotCourse(string destinationName, string sector)
    //     {
    //         Console.WriteLine($"{destinationName} {sector}");
    //     }

    private static bool ScanPlanet(string planetName, out string atmosphereInfo)
    {
        if (planetName == "Kelper-186f")
        {
            atmosphereInfo = "Nitrogen-Oxygen mix. Breathable";
            return true;
        }
        else
        {
            atmosphereInfo = "Toxic";
            return false;
        }
    }

    private static void SustainDamage(ref int systemPower)
    {
        Console.WriteLine($"Draining power...");
        systemPower -= 40;
    }
}

class Person
{
    public static void DoSomething()
    {
        Console.WriteLine($"I do something");
    }
}
