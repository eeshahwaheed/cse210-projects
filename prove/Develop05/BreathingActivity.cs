using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void ExecuteActivity(int duration)
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            DisplaySpinner(4); // Spinner during inhaling
            
            Console.WriteLine("Breathe out...");
            DisplaySpinner(4); // Spinner during exhaling
        }
    }
}
