public class GratitudeActivity : Activity
{
    private List<string> GratitudePrompts = new List<string>
    {
        "What are you grateful for today?",
        "Who has made a positive impact in your life recently?",
        "What is a recent accomplishment you are proud of?",
        "What is a lesson you learned that you are thankful for?"
    };

    public GratitudeActivity()
        : base("Gratitude Activity",
               "This activity helps you reflect on the things you are grateful for in your life.")
    {
    }

    protected override void ExecuteActivity(int duration)
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        Random random = new Random();

        string prompt = GratitudePrompts[random.Next(GratitudePrompts.Count)];
        Console.WriteLine(prompt);
        Pause(3); // Countdown before starting the reflection

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Take a moment to reflect...");
            DisplaySpinner(5); // Spinner while reflecting
        }
    }
}
