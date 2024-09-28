using System;

public class Program
{
    public static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = myJournal.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.WriteLine("Select your mood:");
                    Console.WriteLine("1. Happy");
                    Console.WriteLine("2. Sad");
                    Console.WriteLine("3. Excited");
                    Console.WriteLine("4. Anxious");
                    int moodChoice = int.Parse(Console.ReadLine());
                    string mood = moodChoice switch
                    {
                        1 => "Happy",
                        2 => "Sad",
                        3 => "Excited",
                        4 => "Anxious",
                        _ => "Neutral"
                    };

                    myJournal.AddEntry(prompt, response, mood);
                    break;

                case "2":
                    myJournal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save journal: ");
                    string saveFilename = Console.ReadLine();
                    myJournal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter filename to load journal: ");
                    string loadFilename = Console.ReadLine();
                    myJournal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
