using System.Collections.Generic;

public class Video
{
    public string Title;
    public string Author;
    public int LengthInSeconds;  // Length of the video in seconds
    public List<Comment> Comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comments.Add(new Comment(commenterName, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

