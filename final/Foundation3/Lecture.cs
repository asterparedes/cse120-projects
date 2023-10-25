using System;

public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(string title, string description, string date, string time, Address address, string name, int capacity) : base(title, description, date, time, address)
    {
        _eventType = "Lecture";
        _speakerName = name;
        _capacity = capacity;
        _fullDetails = $"{DisplayStandardDetails()} \nEvent Type: Lecture\nSpeaker: {_speakerName}\nCapacity: {_capacity} attendees";
    }
}