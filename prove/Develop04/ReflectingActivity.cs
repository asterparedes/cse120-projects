using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 0;

        InitializePrompts();
        InitializeQuestions();
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            InitializePrompts();
        }

        Random randomPrompt = new Random();
        int randomPromptIndex = randomPrompt.Next(0, _prompts.Count);
        string randomString = _prompts[randomPromptIndex];
        _prompts.RemoveAt(randomPromptIndex);
        return randomString;
    }

    public string GetRandomQuestion()
    {
        if (_questions.Count == 0)
        {
            InitializeQuestions();
        }

        Random randomQuestion = new Random();
        int randomQuestionIndex = randomQuestion.Next(0, _questions.Count);
        string randomString = _questions[randomQuestionIndex];
        return randomString;
    }

    public void InitializePrompts()
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

    }

    public void InitializeQuestions()
    {
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
        _questions.Add("How did you get started?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you feel when it was complete?");
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        Console.WriteLine();
        Console.WriteLine("Now ponder each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {GetRandomQuestion()} ");
            ShowSpinner(10);
        }
    }

}