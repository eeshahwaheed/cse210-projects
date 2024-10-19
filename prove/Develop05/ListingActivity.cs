using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    public ListingActivity() 
        : base("Listing Activity", 
               "This activity helps you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void ExecuteActivity(int duration)
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        Random random = new Random();
        
        string[] prompts = 
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Pause(3); // Countdown before listing
        
        List<string> items = new List<string>();
        
        Console.WriteLine("Start listing items (press Enter after each one).");
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items.");
    }
}
