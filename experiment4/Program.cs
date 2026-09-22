using System;

class Distance
{
    public int meters;

    public Distance(int meters)
    {
        this.meters = meters;
    }

    // Unary operator overloading
    public static Distance operator -(Distance d)
    {
        return new Distance(-d.meters);
    }

    // Binary operator overloading
    public static Distance operator +(Distance d1, Distance d2)
    {
        return new Distance(d1.meters + d2.meters);
    }

    public void Display()
    {
        Console.WriteLine("Distance: " + meters + " meters");
    }
}

class Program
{
    static void Main()
    {
        Distance d1 = new Distance(150);
        Distance d2 = new Distance(250);

        Console.WriteLine("--- Unary Operator ---");
        Console.WriteLine("Original distance:");
        d1.Display();

        Distance negativeDistance = -d1;

        Console.WriteLine("After unary - operator:");
        negativeDistance.Display();

        Console.WriteLine("\n--- Binary Operator ---");

        Distance total = d1 + d2;

        Console.WriteLine("First distance:");
        d1.Display();

        Console.WriteLine("Second distance:");
        d2.Display();

        Console.WriteLine("Combined distance:");
        total.Display();
    }
}