using System;

public class Swimming : Activity
{
    private int _laps; // unique attribute for Swimming

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps; // unique attribute for Swimming
    }

    public override double GetDistance() => (_laps * 50 / 1000) * 0.62; // distance in miles

    public override double GetSpeed() => (GetDistance() / _duration) * 60; // mph

    public override double GetPace() => _duration / GetDistance(); // min/mile
}

