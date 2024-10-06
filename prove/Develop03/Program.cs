using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found. Exiting.");
            return;
        }

        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        Console.WriteLine("Memorize the following scripture:");
        Console.WriteLine(selectedScripture);
        
        while (true)
        {
            Console.WriteLine("\nPress Enter to hide some words or type 'quit' to exit.");
            string userInput = Console.ReadLine();
            
            if (userInput?.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine(selectedScripture);
            
            if (selectedScripture.AllWordsHidden())
            {
                Console.WriteLine("All words have been hidden. Great job!");
                break;
            }
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        var scriptures = new List<Scripture>();
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split('|');
            if (parts.Length < 2) continue;

            var reference = parts[0].Trim();
            var text = parts[1].Trim();

            var refParts = reference.Split(' ');
            var book = refParts[0];
            var chapterVerse = refParts[1].Split(':');
            var chapter = int.Parse(chapterVerse[0]);
            var verseParts = chapterVerse[1].Split('-');
            var verse = int.Parse(verseParts[0]);
            var endVerse = verseParts.Length > 1 ? int.Parse(verseParts[1]) : verse;

            var scriptureReference = new Reference(book, chapter, verse, endVerse);
            scriptures.Add(new Scripture(scriptureReference, text));
        }
        return scriptures;
    }
}// program works with a library of scriptures, randomly selecting one for the user to memorize, and allows for incremental hiding of words to aid in memorization.