using System;

public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed; // unique attribute for Cycling
    }

    public override double GetDistance() => (_speed * _duration) / 60; // distance in miles

    public override double GetSpeed() => _speed; // mph

    public override double GetPace() => 60 / _speed; // min/mile
}


