using System;
using System.IO.Pipes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program");
    
        bool isRunning = true;
        PromptGenerator promptGenerator = new PromptGenerator();
        promptGenerator._prompts.Add("What is the highlight of my day?");
        promptGenerator._prompts.Add("Who was the most interesting person I interacted with today?");
        promptGenerator._prompts.Add("What is the lesson I have learned today?");
        promptGenerator._prompts.Add("What do I need to improve today to be better tomorrow?");
        promptGenerator._prompts.Add("What are the things I am grateful for today?");

        Journal theJournal = new Journal();

        while (isRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            choice = choice.ToLower();

            // The user can choose between a number or a word. 
            if (choice == "1" || choice == "write")
            {
                DateTime theCurrentTime = DateTime.Now;
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);

                Entry anEntry = new Entry();
                anEntry._date = theCurrentTime.ToShortDateString();
                anEntry._promptText = prompt;
                anEntry._entryText = Console.ReadLine();
                theJournal.AddEntry(anEntry);
            }

            else if (choice == "2" || choice == "display")
            {
                theJournal.DisplayAll();
            }

            else if (choice == "3" || choice == "save")
            {
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }

            else if (choice == "4" || choice == "load")
            {
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }

            else if (choice == "5" || choice == "quit")
            {
                isRunning = false;
            }

            // Suppose the user makes the wrong choice. 
            // The message will appear, and the program will ask the user again 
            // to select one option in a menu. 
            else
            {
                Console.WriteLine("Invalid choice. Please try again!");
            }
        }  
    }
}