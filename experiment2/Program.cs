using System;

class BankAccount
{
    public string accountHolder;
    public double balance;

    public void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine("Amount deposited: " + amount);
    }

    public void DisplayBalance()
    {
        Console.WriteLine("Current Balance: " + balance);
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        Console.Write("Enter account holder name: ");
        account.accountHolder = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        account.balance = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter deposit amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        account.Deposit(amount);

        Console.WriteLine("\n--- Bank Account Details ---");
        Console.WriteLine("Account Holder : " + account.accountHolder);
        account.DisplayBalance();
    }
}