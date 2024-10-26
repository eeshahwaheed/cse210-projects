using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    isRunning = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation failed.");
                break;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score); // Save the current score
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals successfully saved!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear(); // Clear existing goals before loading new ones

            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine()); // Load the score first

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string goalType = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    if (goalType == "SimpleGoal")
                    {
                        bool isComplete = bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(name, description, points, isComplete));
                    }
                    else if (goalType == "EternalGoal")
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                    }
                }
            }
            Console.WriteLine("Goals successfully loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int choice = int.Parse(Console.ReadLine());

        if (choice > 0 && choice <= _goals.Count)
        {
            Goal goal = _goals[choice - 1];
            goal.RecordEvent();
            _score += goal.Points;
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
}

// Base class for all goals
public abstract class Goal
{
    protected string _shortName; // Goal name
    protected string _description; // Goal description
    protected int _points; // Points awarded for the goal

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent(); // Abstract method to record an event
    public abstract bool IsComplete(); // Abstract method to check if the goal is complete
    public abstract string GetStringRepresentation(); // Abstract method for string representation

    // Returns details for displaying the goal
    public virtual string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName} - {_description} : {_points} points";
    }

    public int Points => _points; // Property to get points
}

// Simple goal class
public class SimpleGoal : Goal
{
    private bool _isComplete; // Tracks completion status

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete; // Initialize completion status
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true; // Mark as complete
            Console.WriteLine($"{_shortName} completed! +{_points} points.");
        }
        else
        {
            Console.WriteLine($"{_shortName} is already complete.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete; // Return completion status
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}

// Eternal goal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Eternal Goal recorded! +{_points} points.");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals never complete
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}

// Checklist goal class
public class ChecklistGoal : Goal
{
    private int _amountCompleted; // Number of times completed
    private int _target; // Target number of completions
    private int _bonus;// Bonus points for completion
    private int _totalPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted; // Initialize completed count
        _target = target; // Set target completions
        _bonus = bonus;
        _totalPoints = points * amountCompleted; // Set bonus points
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        _totalPoints += Points;  // Increment completed count
        Console.WriteLine($"Progress made! Completed {_amountCompleted}/{_target}.");

        // Award points for this completion
        Console.WriteLine($"+{Points} points awarded for this completion!");

        // Check for bonus points
        if (_amountCompleted >= _target)
        {
            Console.WriteLine($"Checklist goal completed! +{_bonus} bonus points!");
            _totalPoints += _bonus;; // Award the bonus
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target; // Return completion status
    }

    public override string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName} - {_description} : Completed {_amountCompleted}/{_target}, Total Points: {_totalPoints}, Bonus: {_bonus}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_totalPoints}|{_amountCompleted}|{_target}|{_bonus}";
    }

     public int TotalPoints => _totalPoints;
}
