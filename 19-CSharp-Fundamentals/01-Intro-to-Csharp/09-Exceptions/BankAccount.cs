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
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
}
