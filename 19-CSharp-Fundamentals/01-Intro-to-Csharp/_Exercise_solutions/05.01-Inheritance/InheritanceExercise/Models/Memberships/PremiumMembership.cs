namespace InheritanceExercise.Models.Memberships;

public class PremiumMembership : Membership
{
    public PremiumMembership(string memberName)
        : base(memberName) { }

    public override string GetBenefits()
    {
        return "Newsletter, Fitnessraum, Sauna, alle Kurse";
    }
}
