using System;
using System.Text.Json;
using System.Text.Encodings.Web;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base (name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        ++_amountCompleted; 
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $" [X] {_shortName} ({_description}) --- Currently completed: {_amountCompleted}/{_target}";
        }
        else 
        {
            return $" [ ] {_shortName} ({_description}) --- Currently completed: {_amountCompleted}/{_target}";
        }
    }

    public override string GetStringRepresentation()
    {
        ChecklistData goalData = new ChecklistData();
        goalData.shortName = _shortName;
        goalData.description = _description;
        goalData.points = _points;
        goalData.amountCompleted = _amountCompleted;
        goalData.target = _target;
        goalData.bonus = _bonus;
        goalData.isCompleted = IsComplete();

        string jsonString = JsonSerializer.Serialize(goalData, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

        return jsonString;
    }

    public int GetBonus()
    {
        return _bonus;
    }
}

public class ChecklistData : GoalData
{
    public int amountCompleted {get; set;}
    public int target {get; set;}
    public int bonus {get; set;}
}