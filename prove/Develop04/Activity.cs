using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    } 

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!!");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
        ShowSpinner(5);
    }

     public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>();
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("-");
        spinner.Add("\\");
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("-");
        spinner.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
       while (DateTime.Now < endTime)
        {
            string spin = spinner[i];
            Console.Write(spin);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        } 
    }
    
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; --i)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
