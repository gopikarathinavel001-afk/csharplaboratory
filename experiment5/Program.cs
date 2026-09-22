using System;
using System.Threading;

class ThreadExample
{
    public void MultiplicationTable()
    {
        Console.WriteLine("--- Multiplication Table ---");

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("7 x " + i + " = " + (7 * i));
            Thread.Sleep(500);
        }
    }

    public void Countdown()
    {
        Console.WriteLine("\n--- Countdown ---");

        for (int i = 5; i >= 1; i--)
        {
            Console.WriteLine("Countdown: " + i);
            Thread.Sleep(500);
        }
    }
}

class Program
{
    static void Main()
    {
        ThreadExample example = new ThreadExample();

        Thread tableThread = new Thread(example.MultiplicationTable);
        Thread countdownThread = new Thread(example.Countdown);

        Console.WriteLine("Starting threads...\n");

        tableThread.Start();
        countdownThread.Start();

        tableThread.Join();
        countdownThread.Join();

        Console.WriteLine("\nBoth threads completed successfully.");
    }
}