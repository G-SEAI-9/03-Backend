namespace InheritanceExercise.Models.Memberships;

public class LifetimeMembership : Membership
{
    public LifetimeMembership(string memberName)
        : base(memberName) { }

    // * sealed override: Hier wird GetBenefits zum letzten Mal überschrieben.
    public sealed override string GetBenefits()
    {
        return "Alles aus Premium, ein Leben lang";
    }
}

// Der Versuch aus der Aufgabe. Er baut nicht, deshalb bleibt er auskommentiert.
// Von LifetimeMembership erben geht, nur GetBenefits darf HonoraryMembership nicht mehr überschreiben.
// public class HonoraryMembership : LifetimeMembership
// {
//     public HonoraryMembership(string memberName) : base(memberName) { }
//
//     public override string GetBenefits() // Fehler: GetBenefits ist in LifetimeMembership sealed
//     {
//         return "Noch mehr";
//     }
// }
