using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Moroni",7,33,34);
        Scripture scripture = new Scripture(reference,"And Christ hath said: If ye will have faith in me ye shall have power to do whatsoever this is expedient in me. And he hath said: Repent all ye ends of the earth, and come unto me, and be baptized in my name, and have faith in me, that ye may be saved.");
        string response = "";
        
        do 
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            
            if (scripture.IsCompletelyHidden() == true)
            {
                break;
            }
    
            response = Console.ReadLine();
            if (response != "quit")
            {
                scripture.HideRandomWords(6);
            }
        } while (response != "quit");
    }
}       