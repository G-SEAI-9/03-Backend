class Program
{
    public static void Main(string[] args)
    {
        // IfElse();

        // int number = 20;
        // string result = number % 2 == 0 ? "Even" : "Odd";
        // Console.WriteLine($"{result}");

        // int userTierCode = 2;

        // string tierDescription = userTierCode switch
        // {
        //     1 => "Standard Tier: Basic accoount access.",
        //     2 => "Gold Tier: Fee waivers and 1% cash back",
        //     3 => "Platinum Tier: Premium support and 3% cash back",
        //     _ => "Invalid Tier: Contact system administrator",
        // };

        // Console.WriteLine($"User status: {tierDescription}");

        // Loop();
        // GuardClause();

        Console.Write($"What is your name? ");
        string? userInput = Console.ReadLine()?.Trim();
        // Console.WriteLine($"{(string.IsNullOrWhiteSpace(userInput) ? "Guest" : userInput)}");

        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine($"Hello Guest");
        }
        else
        {
            Console.WriteLine($"Hello {userInput}");
        }
    }

    public static void IfElse()
    {
        decimal accountBalance = 250.00m;
        decimal withdrawalAmount = 100.00m;
        bool isAccountActive = true;

        if (isAccountActive && accountBalance >= withdrawalAmount)
        {
            accountBalance -= withdrawalAmount;
            Console.WriteLine($"Withdrawal approved. Reminaing balance: {accountBalance:C}");
        }
        else if (!isAccountActive)
        {
            Console.WriteLine($"Transaction declined: Account is suspended");
        }
        else
        {
            Console.WriteLine($"Transaction declined: Insufficient balance");
        }
    }

    public static void Loop()
    {
        decimal balance = 1000.00m;
        decimal interestRate = 0.03m;
        Console.WriteLine($"5 Year Savings Projection");

        for (int year = 0; year <= 5; year++)
        {
            balance += balance * interestRate;
            Console.WriteLine($"End of Year {year}: {balance:C}");
        }

        string[] transacionTypes = ["Deposit", "Withdrawal", "Wire Transfer", "Fee Payment"];
        Console.WriteLine($"Processing Transactions");

        foreach (string transacion in transacionTypes)
        {
            Console.WriteLine($"Processing log: Transaction Type -> {transacion}");
        }

        int attempts = 0;
        int maxAttempts = 3;
        bool isConnected = false;

        Console.WriteLine($"Network Connection Attempt");

        while (!isConnected && attempts < maxAttempts)
        {
            attempts++;
            Console.WriteLine($"Attempt {attempts} of {maxAttempts} to reach server");
            if (attempts == 2)
            {
                isConnected = true;
                Console.WriteLine($"Connection successfully established");
            }
        }
    }

    public static void GuardClause()
    {
        void ProcessOrder(decimal amount, bool isVerified)
        {
            if (isVerified)
            {
                if (amount > 0)
                {
                    Console.WriteLine($"Order Processed");
                }
            }
        }

        void ProcessOrderRefactored(decimal amount, bool isVerified)
        {
            if (!isVerified)
                return;
            if (amount <= 0)
                return;

            Console.WriteLine($"Order Processed");
        }

        ProcessOrder(100m, true);
        ProcessOrderRefactored(100m, true);

        ProcessOrder(0m, true);
        ProcessOrderRefactored(0m, true);
    }
}
