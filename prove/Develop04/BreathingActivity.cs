using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breath in...");
            ShowCountDown(4);
            Console.WriteLine();
            Console.Write("Now breath out...");
            ShowCountDown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}