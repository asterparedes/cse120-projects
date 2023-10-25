using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("4228 Lennox Blvd", "Inglewood", "CA", 90304, "USA");
        Address address2 = new Address("143 Oak St", "Townsville", "TX", 56420, "USA");
        Address address3 = new Address("558 7th St", "CityScape", "NY", 14733, "USA");

        Event eventGeneral = new Event("General Event", "A general event.", "11-3-2023", "10:00 AM", address1);
        Lecture lecture = new Lecture("Women's Conference", "To learn and grow together. To help each other in times of need.", "03-22-2024", "10:00am", address2, "Jenny Hill", 200);
        Reception reception = new Reception("Wedding Reception", "To celebrate the happy day of the couple. The happiest day of your life will begin.", "02-14-2024", "3:00 PM", address3, "jvread@gmail.com");
        OutdoorGathering outdoor = new OutdoorGathering("Team Building Activity", "To strengthen our relationship with each other and to build a strong foundation.", "11-3-2023", "10:00 AM", address1, "Sunny day");

        Console.WriteLine("Standard Details:\n");
        Console.WriteLine(lecture.DisplayStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.DisplayStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.DisplayStandardDetails());

        Console.WriteLine("\nFull Details:\n");
        Console.WriteLine(lecture.DisplayFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.DisplayFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.DisplayFullDetails());

        Console.WriteLine("\nShort Description:\n");
        Console.WriteLine(lecture.DisplayShortDescription());
        Console.WriteLine();
        Console.WriteLine(reception.DisplayShortDescription());
        Console.WriteLine();
        Console.WriteLine(outdoor.DisplayShortDescription());
    }
}