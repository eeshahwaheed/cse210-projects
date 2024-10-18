using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Create videos with lengths and comments
        Video video1 = new Video("Understanding Abstraction in C#", "Alice", 300);
        video1.AddComment("Bob", "Great explanation!");
        video1.AddComment("Charlie", "Very helpful, thanks!");
        video1.AddComment("Dana", "Could you go over that last point again?");
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programming Concepts", "Eve", 450);
        video2.AddComment("Frank", "Nice overview!");
        video2.AddComment("Grace", "I learned a lot from this!");
        video2.AddComment("Hank", "This is very informative.");
        videos.Add(video2);

        Video video3 = new Video("C# Basics for Beginners", "Hank", 600);
        video3.AddComment("Ivy", "This is so clear!");
        video3.AddComment("Jack", "Looking forward to the next video.");
        video3.AddComment("Liam", "Well explained!");
        videos.Add(video3);

        // Display video details
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.LengthInSeconds + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetNumberOfComments());
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine("- " + comment.CommenterName + ": " + comment.Text);
            }
            Console.WriteLine();
        }
    }
}
