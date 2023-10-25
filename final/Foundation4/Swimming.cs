using System;

public class Swimming :Activity 
{
    private int _swimmingLaps;
    public Swimming(string date, int duration, int laps) : base(date, duration)
    {
        _swimmingLaps = laps;
        _activityType = "Swimming";
    }

    public override double GetDistance()
    {
        return _swimmingLaps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return GetDistance() / _duration * 60;
    }

    public override double GetPace()
    {
        return _duration / GetDistance();
    }
}