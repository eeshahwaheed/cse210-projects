
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; } // New mood property

    public Entry(string prompt, string response, string date, string mood)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Mood = mood;
    }
}
