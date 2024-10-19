using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        MindfulnessApp app = new MindfulnessApp();
        app.Run();
    }
}

class MindfulnessApp
{
    private List<Activity> _activities;

    public MindfulnessApp()
    {
        _activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option (1-4): ");

            string choice = Console.ReadLine();

            if (choice == "4")
            {
                break; // Exit the program
            }

            if (int.TryParse(choice, out int index) && index >= 1 && index <= _activities.Count)
            {
                _activities[index - 1].Start();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}

abstract class Activity
{
    protected string _name { get; }
    protected string _description { get; }
    protected int _duration { get; private set; }

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Prepare();
        ExecuteActivity();
        EndActivity();
    }

    protected virtual void Prepare()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(3); // Show spinner while preparing
    }

    protected abstract void ExecuteActivity();

    protected void EndActivity()
    {
        Console.WriteLine($"Well done! You completed the {_name} for {_duration} seconds.");
        ShowSpinner(2); // Pause after activity
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[count % spinner.Length]);
            Console.Write("\b \b"); // Backspace to overwrite the spinner character
            count++;
            Thread.Sleep(250); // Adjust the speed of the spinner
        }
        Console.WriteLine(); // Move to the next line after the spinner completes
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly.")
    {
    }

    protected override void ExecuteActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(4); // Show spinner for breathing in
            Console.WriteLine("Breathe out...");
            ShowSpinner(4); // Show spinner for breathing out
        }
    }
}

class ReflectionActivity : Activity
{
    private static readonly string[] _prompts = 
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength.")
    {
    }

    protected override void ExecuteActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("Take a moment to think about this...");
        ShowSpinner(5); // Allow time to consider the prompt

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        foreach (var question in _questions)
        {
            if (DateTime.Now >= endTime)
                break; // Stop if time is up

            Console.WriteLine(question);
            ShowSpinner(10); // Pause for reflection on each question
        }
    }
}

class ListingActivity : Activity
{
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    {
    }

    protected override void ExecuteActivity()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine("You have 10 seconds to think about it...");
        ShowSpinner(10); // Give time to think

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("Start listing items! (Type 'done' to finish)");

        while (DateTime.Now < endTime)
        {
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "done")
            {
                break; // Exit loop if user types 'done'
            }
            items.Add(userInput); // Add user input to the list
        }

        Console.WriteLine($"You listed {items.Count} items.");
    }

    private string GetRandomPrompt()
    {
        string[] prompts = 
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        Random rand = new Random();
        return prompts[rand.Next(prompts.Length)];
    }
}


