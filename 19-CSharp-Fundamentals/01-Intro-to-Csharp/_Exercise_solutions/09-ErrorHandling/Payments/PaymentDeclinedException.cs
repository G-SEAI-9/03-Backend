namespace Shop.Payments;

// * Eine Custom Exception erbt von Exception, reicht message per : base(message) weiter und trägt Fachdaten wie Reason und Amount.
public class PaymentDeclinedException : Exception
{
    public string Reason { get; }
    public decimal Amount { get; }

    public PaymentDeclinedException(string message, string reason, decimal amount)
        : base(message)
    {
        Reason = reason;
        Amount = amount;
    }
}
