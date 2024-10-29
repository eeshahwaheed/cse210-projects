using System;

public class Swimming : Activity
{
    private int _laps; // unique attribute for Swimming

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps; // unique attribute for Swimming
    }

    public override double GetDistance()
    {
        return (_laps * 50 / 1609.34); // convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / (_duration / 60.0)); // speed in mph
    }

    public override double GetPace()
    {
        return _duration / GetDistance(); // pace in min/mile
    }
}

