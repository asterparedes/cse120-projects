using System;
using System.Text.Json;
using System.Text.Encodings.Web;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base (name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
        
    }

    public override bool IsComplete()
    {
        return true;
    }

    public override string GetDetailsString()
    {
        return $" [ ] {_shortName} ({_description})";
    }
    public override string GetStringRepresentation()
    {
        GoalData goalData = new GoalData();
        goalData.shortName = _shortName;
        goalData.description = _description;
        goalData.points = _points;
        goalData.isCompleted = false;

        string jsonString = JsonSerializer.Serialize(goalData, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

        return jsonString;
    }

}