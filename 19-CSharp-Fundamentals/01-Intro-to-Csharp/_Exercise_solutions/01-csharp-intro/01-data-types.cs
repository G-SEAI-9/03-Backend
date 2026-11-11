// Deklarationen und Literale
int age = 30;
long worldPopulation = 8000000000;
float temperature = 36.6F;
double price = 9.99D;
Console.WriteLine(
    $"Alter: {age}, Weltbevölkerung: {worldPopulation}, Temperatur: {temperature}, Preis: {price}"
);

// Console.Write lässt den Cursor in derselben Zeile, Console.WriteLine springt danach in eine neue Zeile.
Console.Write("Console.Write bleibt in dieser Zeile, ");
Console.WriteLine("Console.WriteLine beendet sie.");

// Arithmetik und Ganzzahldivision
int a = 10;
int b = 3;
Console.WriteLine($"a + b = {a + b}");
Console.WriteLine($"a - b = {a - b}");
Console.WriteLine($"a * b = {a * b}");
Console.WriteLine($"a / b = {a / b}");
Console.WriteLine($"a % b = {a % b}");

// a / b teilt zwei ints, deshalb fallen die Nachkommastellen weg. Wenn wir a vorher in einen double casten, bleiben sie erhalten.
Console.WriteLine($"(double)a / b = {(double)a / b}");

// Vergleichs- und logische Operatoren
Console.WriteLine($"a > b: {a > b}");
Console.WriteLine($"a < b: {a < b}");
Console.WriteLine($"a == b: {a == b}");
Console.WriteLine($"a != b: {a != b}");
Console.WriteLine($"a > 5 && b > 5: {a > 5 && b > 5}");
Console.WriteLine($"a > 5 || b > 5: {a > 5 || b > 5}");
Console.WriteLine($"!(a > 5): {!(a > 5)}");

// Wissenschaftliche Schreibweise
double distanceToSunKm = 1.496e8;
double electronMassKg = 9.109e-31;
Console.WriteLine($"Entfernung zur Sonne: {distanceToSunKm} km");
Console.WriteLine($"Elektronenmasse: {electronMassKg} kg");

// Operatorrangfolge
// * wird vor + ausgeführt, also ist result1 gleich 2 + 12. Klammern kommen zuerst, also ist result2 gleich 5 * 4.
int result1 = 2 + 3 * 4;
int result2 = (2 + 3) * 4;
Console.WriteLine($"result1: {result1}");
Console.WriteLine($"result2: {result2}");

// Zusammengesetzte Zuweisung und Inkrement
int counter = 0;
counter += 10;
Console.WriteLine($"Nach += 10: {counter}");
counter -= 2;
Console.WriteLine($"Nach -= 2: {counter}");
counter *= 3;
Console.WriteLine($"Nach *= 3: {counter}");
counter /= 4;
Console.WriteLine($"Nach /= 4: {counter}");
counter++;
Console.WriteLine($"Nach ++: {counter}");

// Konvertierungen (Casts) und Runden
double score = 7.85D;
int truncated = (int)score;
double rounded = Math.Round(score, 1);
float scoreF = (float)score;

// Der Cast nach int schneidet die Nachkommastellen ab, ohne zu runden, also ist truncated gleich 7.
// Math.Round behandelt 7.85 als genau in der Mitte, und Hälften werden zur nächsten geraden Zahl gerundet: 7.8, nicht 7.9.
// Der Cast nach float behält den Wert mit weniger Stellen Genauigkeit, und er wird trotzdem als 7.85 ausgegeben.
Console.WriteLine($"truncated: {truncated}");
Console.WriteLine($"rounded: {rounded}");
Console.WriteLine($"scoreF: {scoreF}");

// Overflow-Prüfung (optional)
// checked wirft eine OverflowException, wenn der Wert nicht passt, unchecked läuft über und landet bei einer negativen Zahl.
try
{
    checked
    {
        int max = int.MaxValue;
        Console.WriteLine($"Max int: {max}");
        // Die nächste Zeile wirft im checked-Kontext eine OverflowException
        int boom = max + 1;
        Console.WriteLine($"This will not print (boom={boom})");
    }
}
catch (OverflowException)
{
    Console.WriteLine("Overflow caught in checked context");
}

unchecked
{
    int max = int.MaxValue;
    int wrapped = max + 1; // läuft im unchecked-Kontext über und wird negativ
    Console.WriteLine($"Unchecked wrap-around result: {wrapped}");
}

// Genauigkeit von float und double
float f = 0.1F + 0.2F;
double d = 0.1D + 0.2D;
Console.WriteLine($"f: {f}");
Console.WriteLine($"d: {d}");
Console.WriteLine($"f == d: {f == d}");
Console.WriteLine($"(double)f: {(double)f}");

// 0.1 und 0.2 lassen sich binär nicht exakt speichern, deshalb enthalten beide Ergebnisse Rundungsfehler.
// f wirkt nur genauer, weil float weniger Stellen ausgibt. (double)f macht seinen Rundungsfehler
// sichtbar.
// Für == wandelt C# f in einen double um, und die beiden Werte sind verschieden, also ist das Ergebnis False.
// double ist meist genauer, weil er etwa 15-16 Stellen schafft, float etwa 7.

// Mini-Challenge
double weightKg = 70D;
double heightM = 1.75D;
double bmi = weightKg / (heightM * heightM);
string label = bmi >= 18.5 && bmi < 25 ? "Normal" : "Not normal";
Console.WriteLine($"BMI: {bmi} ({label})");
