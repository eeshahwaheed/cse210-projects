using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int usernumber=-1;
        while(usernumber!=0)
        {
            Console.WriteLine("Enter number (0 to quit):");
            string entries = Console.ReadLine();
            usernumber = int.Parse(entries);
            
            
            if (usernumber != 0)
            {
                numbers.Add(usernumber);
                
            }
    
        }

        int sum=0;
        foreach (int number in numbers)
       {
         sum +=number;
       }

       Console.WriteLine($"The sum is {sum}");

       float average=  ((float)sum)/numbers.Count;
       Console.WriteLine($"The average is {average}");

       int maximum=numbers[0];

       foreach (int number in numbers)
       {
        if(maximum < number)
        {
            maximum=number;
        }
       }

       Console.WriteLine($"The maximum number is {maximum}");
    }
}