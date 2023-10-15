using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
public class GoalsSaveData
{
    public int score {get; set;}
    public List<GoalData> simpleGoals {get; set;}
    public List<GoalData> eternalGoals {get; set;}
    public List<ChecklistData> checklistGoals {get; set;}
}

public class GoalManager 
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        do 
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
        }
        while (choice != "6");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for(int i = 0; i < _goals.Count; ++i)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for(int i = 0; i < _goals.Count; ++i)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        string choice = "";
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.Write("what is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
            _goals.Add(simpleGoal);
        }
        else if (choice == "2")
        {
            Console.Write("what is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goals.Add(eternalGoal);
        }
        else if (choice == "3")
        {
            Console.Write("what is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("How many times does this goal need to be accomplished for a bonus?  ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
    }

    public void RecordEvent()
    {
        if(_goals.Count == 0) return;
        
        ListGoalNames();

        Console.Write("which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine());

        Goal goal = _goals[goalIndex - 1];
        goal.RecordEvent();

        int points = goal.GetGoalPoints();

        ChecklistGoal checklistGoal = goal as ChecklistGoal;
        if (checklistGoal != null && goal.IsComplete())
        {
            points += checklistGoal.GetBonus();
        }

        _score += points;
        Console.WriteLine($"Congratulations! You have earned {points} points");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        GoalsSaveData saveData = new GoalsSaveData();
        saveData.score = _score;
        saveData.simpleGoals = new List<GoalData>();
        saveData.eternalGoals = new List<GoalData>();
        saveData.checklistGoals = new List<ChecklistData>();

        foreach (Goal goal in _goals)
        {
            SimpleGoal simpleGoal = goal as SimpleGoal;
            if (simpleGoal != null)
            {
                GoalData goalData = JsonSerializer.Deserialize<GoalData>(simpleGoal.GetStringRepresentation());
                saveData.simpleGoals.Add(goalData);
            }
            EternalGoal eternalGoal = goal as EternalGoal;
            if (eternalGoal != null)
            {
                GoalData goalData = JsonSerializer.Deserialize<GoalData>(eternalGoal.GetStringRepresentation());
                saveData.eternalGoals.Add(goalData);
            }
            ChecklistGoal checklistGoal = goal as ChecklistGoal;
            if (checklistGoal != null)
            {
                ChecklistData goalData = JsonSerializer.Deserialize<ChecklistData>(checklistGoal.GetStringRepresentation());
                saveData.checklistGoals.Add(goalData);
            }
        }

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            string jsonString = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            outputFile.WriteLine(jsonString);
            outputFile.Close();
        }
    }

    public void LoadGoals()
    {
        _goals.Clear();
        
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        string jsonString = File.ReadAllText(file);

        GoalsSaveData saveData = JsonSerializer.Deserialize<GoalsSaveData>(jsonString);

        _score = saveData.score;

        foreach(GoalData goalData in saveData.simpleGoals)
        {
            SimpleGoal goal = new SimpleGoal(goalData.shortName, goalData.description, goalData.points);
            if(goalData.isCompleted)
            {
                goal.RecordEvent();
            }
            _goals.Add(goal);
        }

        foreach(GoalData goalData in saveData.eternalGoals)
        {
            EternalGoal goal = new EternalGoal(goalData.shortName, goalData.description, goalData.points);
            if(goalData.isCompleted)
            {
                goal.RecordEvent();
            }
            _goals.Add(goal);
        }

        foreach(ChecklistData goalData in saveData.checklistGoals)
        {
            ChecklistGoal goal = new ChecklistGoal(goalData.shortName, goalData.description, goalData.points, goalData.target, goalData.bonus);
            for(int i = 0; i < goalData.amountCompleted; ++i)
            {
                goal.RecordEvent();
            }
            _goals.Add(goal);
        }
    }
}