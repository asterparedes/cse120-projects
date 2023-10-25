using System;

public class Cycling : Activity 
{
    private double _speedInMph;

    public Cycling(string date, int duration, double speed) : base(date, duration)
    {
        _speedInMph = speed;
        _activityType = "Cycling";
    }

    public override double GetDistance()
    {
        return _speedInMph / 60 * _duration;
    }

    public override double GetSpeed()
    {
        return _speedInMph;
    }

    public override double GetPace()
    {
        return 60 / _speedInMph;
    }
}