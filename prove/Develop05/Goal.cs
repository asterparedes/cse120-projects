using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        if (IsComplete())
        {
            return $" [X] {_shortName} ({_description})";
        }
        else
        {
            return $" [ ] {_shortName} ({_description})";
        }
    }

    public abstract string GetStringRepresentation();

    public string GetShortName()
    {
        return _shortName;
    }

    public int GetGoalPoints()
    {
        return _points;
    }
}

public class GoalData
{
    public string shortName {get; set;}
    public string description {get; set;}
    public int points {get; set;}
    public bool isCompleted {get; set;}
}