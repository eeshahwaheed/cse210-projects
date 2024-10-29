using System;

public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance; // unique attribute for Running
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / _duration) * 60; // mph

    public override double GetPace() => _duration / _distance; // min/mile
}
