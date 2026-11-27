namespace ModellingTypes.Models;

public record Transaction(
    Guid Id,
    TransactionType Type,
    string Description,
    Money Amount,
    DateTimeOffset Timestamp
) : IReportable
{
    public string ToReportLine()
    {
        // 2026-03-03 Expense 950.00 EUR Rent
        return $"{Timestamp:yyyy-MM-dd} {Type} {Amount} {Description}";
    }
}
