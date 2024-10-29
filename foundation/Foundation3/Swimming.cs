using System;

public class Swimming : Activity
{
    private int _laps; 

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps; 
    }

    public override double GetDistance()
    {
        return (_laps * 50 / 1609.34); 
    }

    public override double GetSpeed()
    {
        return (GetDistance() / (_duration / 60.0)); 
    }

    public override double GetPace()
    {
        return _duration / GetDistance(); 
    }
}

