using System;

class Person
{
    public void ShowPerson()
    {
        Console.WriteLine("Person can communicate.");
    }
}

class Student : Person
{
    public void Study()
    {
        Console.WriteLine("Student studies subjects.");
    }
}

class Employee
{
    public void Work()
    {
        Console.WriteLine("Employee performs work.");
    }
}

class Developer : Employee
{
    public void Code()
    {
        Console.WriteLine("Developer writes programs.");
    }
}

class SeniorDeveloper : Developer
{
    public void LeadTeam()
    {
        Console.WriteLine("Senior developer leads the team.");
    }
}

interface ICamera
{
    void TakePhoto();
}

interface IMusicPlayer
{
    void PlayMusic();
}

class SmartPhone : ICamera, IMusicPlayer
{
    public void TakePhoto()
    {
        Console.WriteLine("Smartphone takes a photo.");
    }

    public void PlayMusic()
    {
        Console.WriteLine("Smartphone plays music.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Single Inheritance ---");

        Student student = new Student();
        student.ShowPerson();
        student.Study();

        Console.WriteLine("\n--- Multilevel Inheritance ---");

        SeniorDeveloper developer = new SeniorDeveloper();
        developer.Work();
        developer.Code();
        developer.LeadTeam();

        Console.WriteLine("\n--- Multiple Inheritance using Interfaces ---");

        SmartPhone phone = new SmartPhone();
        phone.TakePhoto();
        phone.PlayMusic();
    }
}