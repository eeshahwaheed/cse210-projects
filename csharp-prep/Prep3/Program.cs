using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicnumber = randomGenerator.Next(1, 101);

        int guess = 0;

        Console.WriteLine("What is your guess?");
        
        while(guess!=magicnumber)
        {
            guess = int.Parse(Console.ReadLine());

            if(guess<magicnumber)
            { Console.WriteLine("Higher");}
            else if(guess>magicnumber)
            { Console.WriteLine("Lower");}
            else
            {Console.WriteLine("You guessed it!");}
            
        }
     }
}
    
    
    
