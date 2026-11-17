using EncapsulationExercise.Models;

// 1. Thermometer
Console.WriteLine("--- Thermometer ---");
var thermometer = new Thermometer();
Console.WriteLine($"Start: {thermometer.TemperatureCelsius} °C = {thermometer.GetFahrenheit()} °F");

thermometer.SetTemperature(25);
Console.WriteLine($"Neu: {thermometer.TemperatureCelsius} °C = {thermometer.GetFahrenheit()} °F");

thermometer.SetTemperature(150); // zu heiß, wird abgelehnt
Console.WriteLine($"Immer noch: {thermometer.TemperatureCelsius} °C");

// thermometer.TemperatureCelsius = 30; // Fehler: Der Setter ist private

// 2. Student
Console.WriteLine();
Console.WriteLine("--- Student ---");
var student = new Student("Anna");
student.Introduce();

student.UpdateGrade(85);
student.Introduce();

student.UpdateGrade(120); // zu hoch, wird abgelehnt
Console.WriteLine($"{student.Name} hat weiterhin die Note {student.Grade}.");

// student.Grade = 100;   // Fehler: Der Setter ist private
// student.Name = "Ben";  // Fehler: Name hat gar keinen Setter

// 3. Door
Console.WriteLine();
Console.WriteLine("--- Door ---");
var door = new Door();
door.Status();

door.Open();
door.Status();
Console.WriteLine($"IsOpen: {door.IsOpen}");

door.Close();
door.Status();

// door.IsOpen = true; // Fehler: Der Setter ist private
