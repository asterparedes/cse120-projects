using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration = 0;
        _count = 0;

        InitializePrompts();
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetListFromUser();
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

    public void InitializePrompts()
    {
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people the you appreciate?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are the people that you have helped this week?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public List<string> GetListFromUser()
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            ++_count;
        }
        Console.WriteLine($"You listed {_count} items!");
        return _prompts;
    }

}