using System;

public class Reception : Event
{
    private string _email;

    public Reception(string title, string description, string date, string time, Address address, string email) : base(title, description, date, time, address)
    {
        _eventType = "Reception";
        _email = email;
        _fullDetails = $"{DisplayStandardDetails()} \nEvent Type: Reception\nRSVP Email: {_email}";
    }
}