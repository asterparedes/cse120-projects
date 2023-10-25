using System;

public class Event
{
    protected string _eventType;
    protected string _fullDetails;
    protected string _eventTitle;
    protected string _description;
    protected string _eventDate;
    protected string _eventTime;
    protected Address _eventAddress;

    public Event(string title, string description, string date, string time, Address address)
    {
        _eventType = "General";
        _eventTitle = title;
        _description = description;
        _eventDate = date;
        _eventTime = time;
        _eventAddress = address;
        _fullDetails = $"{DisplayStandardDetails()} Event Type: General";
    }

    public string DisplayStandardDetails()
    {
        return $"Event Title: {_eventTitle}\nDescription: {_description}\nDate: {_eventDate}\nTime: {_eventTime}\nAddress: {_eventAddress.GetAddress()}";
    }
    
    public string DisplayFullDetails()
    {
        return _fullDetails;
    }
    
    public string DisplayShortDescription()
    {
        return $"Event Type: {_eventType}\nEvent Title: {_eventTitle}\nDate: {_eventDate}";
    }
}