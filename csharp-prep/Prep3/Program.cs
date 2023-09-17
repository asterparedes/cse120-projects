using System;
using System.Data.Common;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // For Core Requirements 1 and 2.
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        // 3. Core Requirements
        // Use to generate a random number
        Random randomNumber = new Random();
        int magicNumber = randomNumber.Next(1, 100);

        int guess = -1;
        int guessCount = 0;

        // 2. Core Requirements
        // Using the while loop to keep the user guess the number so it will keep looping.
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            // 1. Stretch Challenge
            // To keep track the number of guesses. 
            guessCount += 1;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"You guessed {guessCount} times!");
            }

            // 2. Stretch Challenge
            // Ask the user if they want to continue the game.
            if (guess == magicNumber)
            {
                Console.Write("Do you want to continue? ");
                string userAnswer = Console.ReadLine();
                if (userAnswer.ToLower() == "yes")
                {
                    guessCount = 0;
                    magicNumber = randomNumber.Next(1, 100);
                }
                else 
                {
                    Console.WriteLine("Thank you for playing!");
                }
            }
        }   
    }
}