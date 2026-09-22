using System;

class Employee
{
    static void Main()
    {
        string name;
        double basicSalary, bonus, totalSalary;

        Console.Write("Enter employee name: ");
        name = Console.ReadLine();

        Console.Write("Enter basic salary: ");
        basicSalary = Convert.ToDouble(Console.ReadLine());

        bonus = basicSalary * 0.10;
        totalSalary = basicSalary + bonus;

        Console.WriteLine("\n--- Employee Salary Details ---");
        Console.WriteLine("Employee Name : " + name);
        Console.WriteLine("Basic Salary  : " + basicSalary);
        Console.WriteLine("Bonus (10%)   : " + bonus);
        Console.WriteLine("Total Salary  : " + totalSalary);
    }
}