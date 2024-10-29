using System;

public class Running : Activity
{
    private double _distance; 

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance; 
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / _duration) * 60;

    public override double GetPace() => _duration / _distance; 
}
