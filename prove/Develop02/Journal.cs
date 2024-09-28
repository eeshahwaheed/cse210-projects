using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>(); // List to store entries

    public void AddEntry(string prompt, string response, string mood)
    {
        var newEntry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd"), mood);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt} - {entry.Response} (Mood: {entry.Mood})");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear current entries
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    var entry = new Entry(parts[1], parts[2], parts[0], parts[3]);
                    entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded from file.");
    }

    public string GetRandomPrompt()
    {
        var prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
