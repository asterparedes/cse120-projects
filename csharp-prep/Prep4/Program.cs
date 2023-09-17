using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int newNumber = -1;

        while (newNumber != 0)
        {
            Console.Write("Enter number: ");
            newNumber = int.Parse(Console.ReadLine());
            
            if (newNumber != 0)
            {
                numbers.Add(newNumber);
            }
        }

        int total = 0;
        int largestNumber = -int.MaxValue;
        int smallestNumber = int.MaxValue;

        for (int i = 0; i < numbers.Count; ++i)
        {
            int currentNumber = numbers[i];
            total += currentNumber;
            if (largestNumber < currentNumber) 
            {
                largestNumber = currentNumber;
            }

            if (smallestNumber > currentNumber)
            {
                smallestNumber = currentNumber;
            }
        }

        float average = total / (float)numbers.Count;

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestNumber}");
    }
}