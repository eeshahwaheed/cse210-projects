using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0), // 3 miles
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0), // 15 mph
            new Swimming(new DateTime(2022, 11, 5), 30, 20)   // 20 laps
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary()); // Calls GetSummary, which uses overridden methods
        }
    }
}
