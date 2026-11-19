namespace InheritanceExercise.Models.Memberships;

public class Membership
{
    public string MemberName { get; }

    public Membership(string memberName)
    {
        MemberName = memberName;
    }

    public virtual string GetBenefits()
    {
        return "Newsletter";
    }
}
