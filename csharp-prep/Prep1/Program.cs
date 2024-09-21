using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?");
        string one = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string two = Console.ReadLine();
        Console.WriteLine($"Your name is {two},{one} {two}. ");
    }
}