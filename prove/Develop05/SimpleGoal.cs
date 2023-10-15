using System;
using System.Text.Json;
using System.Text.Encodings.Web;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base (name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        GoalData goalData = new GoalData();
        goalData.shortName = _shortName;
        goalData.description = _description;
        goalData.points = _points;
        goalData.isCompleted = IsComplete();

        string jsonString = JsonSerializer.Serialize(goalData, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

        return jsonString;
    }
}