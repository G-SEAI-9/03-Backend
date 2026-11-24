namespace Exceptions;

public class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; } = 100m;

    public BankAccount(string owner)
    {
        Owner = owner;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Amount must be great than zero."
            );
        }
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InsufficientFundsException(
                $"Attempted to withdraw {amount}, but balance is {Balance}.",
                Balance, // * extra content
                amount // * extra content
            );
        }
        Balance -= amount;
    }
}
