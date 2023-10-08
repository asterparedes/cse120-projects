using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "0";
        do 
        {
            BreathingActivity breathing = new BreathingActivity();
            ReflectingActivity reflecting = new ReflectingActivity();
            ListingActivity listing = new ListingActivity();

            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.Clear();
                breathing.Run();
            }
            else if (choice == "2")
            {
                Console.Clear();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                Console.Clear();
                listing.Run();
            }
        }
        while (choice != "4");
        /* For Showing creativity and exceeding requirements
           Make sure no random prompts/questions are selected until 
           they have all been used at least once in that session.*/
    }
}