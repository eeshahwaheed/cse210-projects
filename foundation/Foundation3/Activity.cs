using System;

public class Activity
{
    private DateTime _date;
    protected int _duration; 

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public virtual double GetDistance() => 0; 
    public virtual double GetSpeed() => 0; 
    public virtual double GetPace() => 0; 


    public virtual string GetSummary()
{
    return $"{_date:dd MMM yyyy} {GetType().Name} ({_duration} min): " +
           $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
}

}
