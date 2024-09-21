using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();
        string username = PromptUserName();
        int usernumber= PromptUserNumber();
        int square= SquareNumber( usernumber);
        DisplayResult(username, square);   
    }

    static void DisplayWelcomeMessage()
    {
    Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name:");
        string username=Console.ReadLine();
        
        return username;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        int usernumber = int.Parse(Console.ReadLine());

        return usernumber;
    }

    static int SquareNumber(int usernumber)
    {
        int square= usernumber * usernumber;
        return square;
    }

    static void DisplayResult(string username, int square)
    {
    Console.WriteLine($"{username},the square of your number is {square} ");
    }

}