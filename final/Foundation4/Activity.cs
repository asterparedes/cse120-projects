using System;
using System.Diagnostics;

public abstract class Activity 
{
    protected string _date;
    protected int _duration;
    protected string _activityType;

    public Activity(string date, int duration)
    {
        _date = date;
        _duration = duration;
        _activityType = "Activity";
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{_date} {_activityType} ({_duration} min): Distance {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace():N2} min per mile";
    }
}