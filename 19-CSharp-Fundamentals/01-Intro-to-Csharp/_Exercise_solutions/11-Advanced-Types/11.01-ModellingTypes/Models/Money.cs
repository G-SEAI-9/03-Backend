namespace ModellingTypes.Models;

// * Ziel (Money):
// var a = new Money(10m, "EUR");
// var b = new Money(5m, "EUR");

// a.Add(b)      → neues Money(15.00 EUR), a bleibt 10.00 EUR
// a.Subtract(b) → neues Money(5.00 EUR),  a bleibt 10.00 EUR
// a.Add(USD)    → InvalidOperationException("Cannot combine EUR with USD.")

public readonly record struct Money(decimal Amount, string Currency)
{
    public Money Add(Money other)
    {
        EnsureSameCurrency(other);

        return this with
        {
            Amount = Amount + other.Amount,
        };
    }

    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);

        return this with
        {
            Amount = Amount - other.Amount,
        };
    }

    public override string ToString()
    {
        return $"{Amount:F2} {Currency}"; // "12.50 EUR"
    }

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency)
        {
            throw new InvalidOperationException(
                $"Cannot combine {Currency} with {other.Currency}."
            );
        }
    }
}
