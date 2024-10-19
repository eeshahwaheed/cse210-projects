public class Activity
{
    protected string Name { get; }
    protected string Description { get; }
    protected int Duration { get; private set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string GetName() // Add this method
    {
        return Name;
    }

    public void Start(int duration)
    {
        Duration = duration;
        Console.WriteLine($"Starting {Name}...");
        Console.WriteLine(Description);
        PrepareForActivity();
        ExecuteActivity(duration);
        EndActivity();
    }

    protected virtual void ExecuteActivity(int duration)
    {
        // Default implementation (can be overridden)
    }

    private void PrepareForActivity()
    {
        Console.WriteLine("Get ready...");
        Pause(3);
    }

    private void EndActivity()
    {
        Console.WriteLine($"Well done! You completed the {Name}.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rPausing for {i} seconds... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void DisplaySpinner(int duration)
    {
        char[] spinnerChars = { '|', '/', '-', '\\' };
        int spinnerIndex = 0;

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{spinnerChars[spinnerIndex]}   ");
            spinnerIndex = (spinnerIndex + 1) % spinnerChars.Length;
            Thread.Sleep(200);
        }
        Console.Write("\r   \r"); // Clear the spinner from the console
    }
}
