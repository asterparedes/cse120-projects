using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03-10-2023", 60, 3.0));
        activities.Add(new Cycling("03-10-2023", 30, 5.2));
        activities.Add(new Swimming("03-10-2023", 30, 5));

        Console.WriteLine();
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine();
    }
}