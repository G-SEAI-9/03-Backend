namespace Shop.Payments;

public class PaymentProcessor
{
    private const decimal Limit = 1000m;

    // * Ungültige Eingaben werfen eingebaute Argument-Exceptions, Geschäftsregeln werfen unsere Custom Exception.
    public void Charge(string cardNumber, decimal amount)
    {
        // ! Eingabeprüfungen stehen vor den Geschäftsregeln: Ein Betrag <= 0 ist ein ungültiges Argument, keine abgelehnte Zahlung.
        // Und erst nach dem Check auf cardNumber ist sicher, dass StartsWith darunter auf keinem null läuft (sonst NullReferenceException).
        if (string.IsNullOrWhiteSpace(cardNumber))
        {
            throw new ArgumentException("Card number is required.", nameof(cardNumber));
        }

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Amount must be greater than zero."
            );
        }

        // Geschäftsregeln: Eingaben sind formal gültig, aber die Zahlung wird abgelehnt
        if (cardNumber.StartsWith("0000", StringComparison.Ordinal))
        {
            throw new PaymentDeclinedException("Payment declined", "Card blocked", amount);
        }

        if (amount > Limit)
        {
            throw new PaymentDeclinedException("Payment declined", "Amount over limit", amount);
        }

        Console.WriteLine($"Charged {amount:0.00} to card {cardNumber}");
    }
}
