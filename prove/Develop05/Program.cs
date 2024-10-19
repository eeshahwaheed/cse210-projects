using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity(),
            new GratitudeActivity() 
        };

        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            if (choice == "5") // Adjusted for the correct exit option
            {
                break; // Exit the program
            }

            if (int.TryParse(choice, out int index) && index >= 1 && index <= activities.Count)
            {
                int duration = GetPositiveDuration();
                activities[index - 1].Start(duration);
                LogActivity(activities[index - 1].GetName(), duration); // Ensure GetName is implemented in Activity
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Gratitude Activity");
        Console.WriteLine("5. Exit"); // Exit option is now correct
        Console.Write("Choose an option (1-5): ");
    }

    private static int GetPositiveDuration()
    {
        while (true)
        {
            Console.Write("Enter duration in seconds (positive integer): ");
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
            {
                return duration;
            }
            Console.WriteLine("Invalid duration. Please enter a positive integer.");
        }
    }

    private static void LogActivity(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now}: Completed {activityName} for {duration} seconds.";
        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }
}
