namespace ModellingTypes.Models;

public class Budget(string name, string currency) : IReportable
{
    // field
    private readonly List<Transaction> _transactions = [];

    public string Name { get; } = name;
    public string Currency { get; } = currency;
    public int Count => _transactions.Count; // number of transactions

    // * Ziel (Balance):
    // Start:   0.00 EUR
    // + Salary (Income,  2500.00 EUR) → 2500.00 EUR
    // - Rent   (Expense,  950.00 EUR) → 1550.00 EUR
    // - Coffee (Expense,    6.80 EUR) → 1543.20 EUR

    public Money Balance
    {
        get
        {
            var total = new Money(0m, Currency);

            foreach (var transaction in _transactions)
            {
                total =
                    transaction.Type == TransactionType.Income
                        ? total.Add(transaction.Amount)
                        : total.Subtract(transaction.Amount);
            }
            return total;
        }
    } // income added, expenses subtracted

    public void Add(Transaction transaction)
    {
        if (transaction.Amount.Currency != Currency)
        {
            throw new InvalidOperationException(
                $"Cannot add transaction in {transaction.Amount.Currency} to budget in {Currency}."
            );
        }
        _transactions.Add(transaction);
    }

    public string ToReportLine()
    {
        // "Budget 'March': 3 transactions, balance 1543.20 EUR"
        return $"Budget '{Name}': {Count} transactions, balance {Balance}";
    }
}
