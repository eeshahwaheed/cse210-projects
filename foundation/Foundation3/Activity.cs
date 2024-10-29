using System;

public class Activity
{
    private DateTime _date;
    protected int _duration; // Change to protected

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public virtual double GetDistance() => 0; // Default implementation
    public virtual double GetSpeed() => 0; // Default implementation
    public virtual double GetPace() => 0; // Default implementation

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_duration} min): " +
               $"Distance {GetDistance():F1}, Speed {GetSpeed():F1}, Pace: {GetPace():F2}";
    }
}
