using PolymorphismExercise.Models.Characters;
using PolymorphismExercise.Models.Exporters;
using PolymorphismExercise.Models.Passes;

// # Aufgabe 1: GameCharacter-Hierarchie
Console.WriteLine("--- GameCharacter ---");
Rogue rogue = new Rogue("Nyx", 7);

// In der Liste stehen alle Objekte nur als GameCharacter
List<GameCharacter> party = new()
{
    new GameCharacter("Tom", 1),
    new Warrior("Kael", 12),
    new Mage("Iris", 10),
    new Healer("Sora", 9),
    rogue,
};

// * Die Schleife kennt nur GameCharacter. Bei override entscheidet trotzdem das Objekt, welche Version läuft.
foreach (GameCharacter character in party)
{
    character.Describe();
    character.UseSpecial();
}

// # Aufgabe 2: Exporter-Hierarchie
Console.WriteLine();
Console.WriteLine("--- Exporter ---");
List<Exporter> exporters =
[
    new PdfExporter("bericht.pdf"),
    new CsvExporter("daten.csv"),
    new HtmlExporter("seite.html"),
    new MarkdownExporter("notizen.md"),
];

foreach (Exporter exporter in exporters)
{
    exporter.Export("sample data");
}

// Exporter plainExporter = new Exporter("text.txt"); // Fehler: Exporter ist abstract, davon gibt es keine Objekte
// exporters[0].PrintStart("PDF"); // Fehler: PrintStart ist protected

// # Aufgabe 3: AccessPass-Hierarchie
Console.WriteLine();
Console.WriteLine("--- AccessPass ---");
DateOnly today = DateOnly.FromDateTime(DateTime.Today);

// Von jeder Art ein gültiger und ein ungültiger Pass
List<AccessPass> passes = new()
{
    new MetroPass("Amina", 2),
    new MetroPass("Ben", 0),
    new BikeSharePass("Jonas", 15),
    new BikeSharePass("Lea", 0),
    new FerryPass("Luca", today.AddDays(3)),
    new FerryPass("Mia", today.AddDays(-1)),
};

foreach (AccessPass pass in passes)
{
    bool isValid = pass.Validate();
    Console.WriteLine($"  Gültig: {isValid}");
}

// # Extra: new gegen override
Console.WriteLine();
Console.WriteLine("--- Rogue über die eigene Referenz ---");

// Dasselbe Rogue-Objekt wie in der Liste, jetzt in einer Variable vom Typ Rogue
rogue.Describe();

// ? Warum fehlt die Rolle des Rogue oben in der Schleife?
// Rogue versteckt Describe mit new. Über GameCharacter läuft deshalb die Version aus GameCharacter.
