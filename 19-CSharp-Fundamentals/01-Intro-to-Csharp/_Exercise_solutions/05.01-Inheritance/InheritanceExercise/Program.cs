using InheritanceExercise.Models.Documents;
using InheritanceExercise.Models.Memberships;
using InheritanceExercise.Models.Shapes;

// # Aufgabe 1: Document-Hierarchie
Console.WriteLine("--- Documents ---");
Document document = new("Hausordnung");
Report report = new("Quartalsbericht", "Amira");
Invoice invoice = new("Webdesign", 250m); // Das m macht aus 250 einen decimal

Console.WriteLine("Über die eigenen Referenzen:");
document.PrintInfo();
report.PrintInfo();
invoice.PrintInfo();

// Dieselben Objekte, jetzt in Variablen vom Typ Document
Document reportAsDocument = report;
Document invoiceAsDocument = invoice;

Console.WriteLine("Über Document-Referenzen:");
reportAsDocument.PrintInfo();
invoiceAsDocument.PrintInfo();

// Console.WriteLine(reportAsDocument.Author); // Fehler: Über eine Document-Referenz kennt der Compiler kein Author

// # Aufgabe 2: Shape-Hierarchie
Console.WriteLine();
Console.WriteLine("--- Shapes ---");
Shape shape = new();
Circle circle = new();
Square square = new();

Console.WriteLine("Über die eigenen Referenzen:");
shape.Draw();
circle.Draw();
square.Draw();

// Dieselben Objekte, jetzt in Variablen vom Typ Shape
Shape circleAsShape = circle;
Shape squareAsShape = square;

Console.WriteLine("Über Shape-Referenzen:");
circleAsShape.Draw(); // Circle versteckt Draw mit new
squareAsShape.Draw(); // Square überschreibt Draw mit override

// ? Warum zeichnet circleAsShape keinen Kreis, obwohl darin ein Circle steckt?
// Bei new entscheidet der Typ der Variable (Shape), bei override das Objekt selbst (Square).

// # Aufgabe 3: Membership-Hierarchie
Console.WriteLine();
Console.WriteLine("--- Memberships ---");
Membership membership = new("Lina");
StandardMembership standard = new("Jonas");
PremiumMembership premium = new("Aisha");
LifetimeMembership lifetime = new("Omar");

Console.WriteLine("Über die eigenen Referenzen:");
Console.WriteLine($"{membership.MemberName}: {membership.GetBenefits()}");
Console.WriteLine($"{standard.MemberName}: {standard.GetBenefits()}");
Console.WriteLine($"{premium.MemberName}: {premium.GetBenefits()}");
Console.WriteLine($"{lifetime.MemberName}: {lifetime.GetBenefits()}");

// Dieselben Objekte, jetzt in Variablen vom Typ Membership
Membership standardAsMembership = standard;
Membership premiumAsMembership = premium;
Membership lifetimeAsMembership = lifetime;

Console.WriteLine("Über Membership-Referenzen:");
Console.WriteLine($"{standardAsMembership.MemberName}: {standardAsMembership.GetBenefits()}");
Console.WriteLine($"{premiumAsMembership.MemberName}: {premiumAsMembership.GetBenefits()}");
Console.WriteLine($"{lifetimeAsMembership.MemberName}: {lifetimeAsMembership.GetBenefits()}");
