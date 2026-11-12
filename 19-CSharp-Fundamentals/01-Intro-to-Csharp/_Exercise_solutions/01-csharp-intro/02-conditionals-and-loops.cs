// * If..Else und Ternary
Console.Write("Wie alt bist du? ");
int age;
while (!int.TryParse(Console.ReadLine(), out age))
{
    Console.Write("Das ist keine gültige Zahl. Wie alt bist du? ");
}

if (age < 13)
{
    Console.WriteLine("Du bist ein Kind.");
}
else if (age < 20)
{
    Console.WriteLine("Du bist ein Teenager.");
}
else
{
    Console.WriteLine("Du bist erwachsen.");
}

// Ein Ternary wählt zwischen zwei Werten, deshalb braucht der dritte Fall einen zweiten Ternary im false-Zweig.
string ageGroup =
    age < 13 ? "Kind"
    : age < 20 ? "Teenager"
    : "erwachsen";
Console.WriteLine($"Der Ternary sagt: {ageGroup}");

// * Switch
Console.Write("Gib eine Note ein (A, B, C, D, F): ");
string? grade = Console.ReadLine();
switch (grade)
{
    case "A":
        Console.WriteLine("Excellent");
        break;
    case "B":
        Console.WriteLine("Good");
        break;
    case "C":
        Console.WriteLine("Average");
        break;
    case "D":
        Console.WriteLine("Below average");
        break;
    case "F":
        Console.WriteLine("Fail");
        break;
    default:
        Console.WriteLine("Unknown grade");
        break;
}

// * While-Schleife
int sum = 0;
int number = 1;
while (number <= 100)
{
    sum += number;
    number++;
}
Console.WriteLine($"Summe von 1 bis 100: {sum}");

// * Do..While-Schleife
int secretNumber = 7;
int guess;
do
{
    Console.Write("Rate eine Zahl zwischen 1 und 10: ");
    // Wenn TryParse scheitert, setzt es guess auf 0, also läuft die Schleife weiter.
    if (!int.TryParse(Console.ReadLine(), out guess))
    {
        Console.WriteLine("Bitte gib eine ganze Zahl ein.");
    }
    else if (guess < secretNumber)
    {
        Console.WriteLine("Zu niedrig.");
    }
    else if (guess > secretNumber)
    {
        Console.WriteLine("Zu hoch.");
    }
} while (guess != secretNumber);
Console.WriteLine("Richtig!");

// * For-Schleife
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{i} x 7 = {i * 7}");
}

// * Break und Continue
for (int i = 1; i <= 20; i++)
{
    if (i % 2 == 0)
    {
        continue;
    }

    if (i == 15)
    {
        break;
    }

    Console.WriteLine(i);
}
