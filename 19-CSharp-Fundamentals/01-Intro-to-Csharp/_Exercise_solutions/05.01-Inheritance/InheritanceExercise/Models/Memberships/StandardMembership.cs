namespace InheritanceExercise.Models.Memberships;

public class StandardMembership : Membership
{
    // Kein neues Property: Der Constructor reicht den Namen nur an Membership weiter
    public StandardMembership(string memberName)
        : base(memberName) { }

    public override string GetBenefits()
    {
        return "Newsletter, Fitnessraum";
    }
}
