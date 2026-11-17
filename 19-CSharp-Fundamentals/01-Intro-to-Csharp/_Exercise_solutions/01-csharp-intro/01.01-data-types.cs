// * Deklarationen und Literale
int age = 30;
long worldPopulation = 8_000_000_000;
float temperature = 36.6F;
double price = 9.99;
Console.WriteLine(
    $"Alter: {age}, Weltbevölkerung: {worldPopulation}, Temperatur: {temperature}, Preis: {price}"
);

// Console.Write lässt den Cursor in derselben Zeile, Console.WriteLine springt danach in eine neue Zeile.
Console.Write("Console.Write bleibt in dieser Zeile, ");
Console.WriteLine("Console.WriteLine beendet sie.");

// * Arithmetik und Ganzzahldivision
int a = 10;
int b = 3;
Console.WriteLine($"a + b = {a + b}");
Console.WriteLine($"a - b = {a - b}");
Console.WriteLine($"a * b = {a * b}");
Console.WriteLine($"a / b = {a / b}"); // 3 <- nicht 3,333!
Console.WriteLine($"a % b = {a % b}");

// a / b teilt zwei ints, deshalb fallen die Nachkommastellen weg. Wenn wir a vorher in einen double casten, bleiben sie erhalten.
Console.WriteLine($"(double)a / b = {(double)a / b}"); // 3.333333333335

// * Vergleichs- und logische Operatoren
Console.WriteLine($"a > b: {a > b}"); // True
Console.WriteLine($"a < b: {a < b}"); // False
Console.WriteLine($"a == b: {a == b}");
Console.WriteLine($"a != b: {a != b}");
Console.WriteLine($"a > 5 && b > 5: {a > 5 && b > 5}"); // False
Console.WriteLine($"a > 5 || b > 5: {a > 5 || b > 5}"); // True
Console.WriteLine($"!(a > 5): {!(a > 5)}");

// * Wissenschaftliche Schreibweise
double distanceToSunKm = 1.496e8; // 1,496 * 10^8 = 149.600.000
double electronMassKg = 9.109e-31; // 9,109 * 10^-31 = 0,00000000...
Console.WriteLine($"Entfernung zur Sonne: {distanceToSunKm} km");
Console.WriteLine($"Elektronenmasse: {electronMassKg} kg");

// * Operatorrangfolge
// * wird vor + ausgeführt, also ist result1 gleich 2 + 12. Klammern kommen zuerst, also ist result2 gleich 5 * 4.
int result1 = 2 + 3 * 4; // 14
int result2 = (2 + 3) * 4; // 20
Console.WriteLine($"result1: {result1}");
Console.WriteLine($"result2: {result2}");

// * Zusammengesetzte Zuweisung und Inkrement
int counter = 0;

// counter  = counter + 10
counter += 10;
Console.WriteLine($"Nach += 10: {counter}");
counter -= 2;
Console.WriteLine($"Nach -= 2: {counter}");
counter *= 3;
Console.WriteLine($"Nach *= 3: {counter}");
counter /= 4;
Console.WriteLine($"Nach /= 4: {counter}");

// counter  = counter + 1
counter++;
Console.WriteLine($"Nach ++: {counter}");

// * Konvertierungen (Casts) und Runden
double score = 7.85;
int truncated = (int)score; // 7 -> double zu int runded nicht, sondern schneidet Kommastellen einfach ab
double rounded = Math.Round(score, 1); // 7.8
float scoreF = (float)score;

// Der Cast nach int schneidet die Nachkommastellen ab, ohne zu runden, also ist truncated gleich 7.
// Math.Round behandelt 7.85 als genau in der Mitte, und Hälften werden zur nächsten geraden Zahl gerundet: 7.8, nicht 7.9.
// C# default: "Banker's rounding": 0,5 wird zur nächsen GERADEN Zahl gerundet.
// Math.Round(2.5) == 2
// Math.Round(3.5) == 4
// "Schools rounding": 0,5 wird immer aufgerunded
Math.Round(score, 1, MidpointRounding.AwayFromZero); // 7.9

// Der Cast nach float behält den Wert mit weniger Stellen Genauigkeit, und er wird trotzdem als 7.85 ausgegeben.
Console.WriteLine($"truncated: {truncated}");
Console.WriteLine($"rounded: {rounded}");
Console.WriteLine($"scoreF: {scoreF}");

// * Overflow-Prüfung (optional)
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

// * Genauigkeit von float und double
// float ca. 7 Stellen
// double etwa 15 oder 16 Stellen
float f = 0.1F + 0.2F;
double d = 0.1D + 0.2D;

// decimal
Console.WriteLine($"f: {f}"); // 0.3
Console.WriteLine($"d: {d}"); // 0.30000000000000004
Console.WriteLine($"f == d: {f == d}"); // False

// 0.1 + 0.2 == 0.3 // False
// 0.1m + 0.2m == 0.3m // True
Console.WriteLine($"(double)f: {(double)f}"); // 0.30000001192092896

// 0.1 und 0.2 lassen sich binär nicht exakt speichern, deshalb enthalten beide Ergebnisse Rundungsfehler.
// f wirkt nur genauer, weil float weniger Stellen ausgibt. (double)f macht seinen Rundungsfehler
// sichtbar.
// Für == wandelt C# f in einen double um, und die beiden Werte sind verschieden, also ist das Ergebnis False.
// double ist meist genauer, weil er etwa 15-16 Stellen schafft, float etwa 7.

// * Mini-Challenge
double weightKg = 70;
double heightM = 1.75;
double bmi = weightKg / (heightM * heightM);

// double bmi = weightKg / Math.Pow(heightM, 2);
string label = (bmi >= 18.5 && bmi < 25) ? "Normal" : "Not normal";
Console.WriteLine($"BMI: {bmi} ({label})");
