using Exceptions;

Console.WriteLine("Exceptions");

var calculator = new Calculator();

try
{
    var result = calculator.Divide(10, 0);
    Console.WriteLine(result);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine($"Program continues...");

Console.WriteLine();

var account = new BankAccount("Aisha");

try
{
    account.Deposit(100m);
    Console.WriteLine($"Deposit successful. New balance: {account.Balance}");

    account.Withdraw(250m);
    Console.WriteLine($"Withdrawal successful. New balance: {account.Balance}");
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Account owner: {account.Owner}");
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine($"Balance: {ex.CurrentBalance}, Attempted: {ex.AttemptedWithdrawal}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Account owner: {account.Owner}");
    Console.WriteLine($"Bad argument: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
finally
{
    Console.WriteLine("Transaction attempt finished.");
}
