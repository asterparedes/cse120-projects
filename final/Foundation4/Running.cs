using System;

public class Running : Activity 
{
    private double _distanceInMiles;

    public Running(string date, int duration, double distance) : base(date, duration)
    {
        _distanceInMiles = distance;
        _activityType = "Running";
    }

    public override double GetDistance()
    {
        return _distanceInMiles;
    }

    public override double GetSpeed()
    {
        return _distanceInMiles / (_duration / 60.0);
    }

    public override double GetPace()
    {
        return _duration / _distanceInMiles;
    }
}