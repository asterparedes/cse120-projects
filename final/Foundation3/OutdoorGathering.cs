using System;

public class OutdoorGathering : Event
{
    private string _weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address)
    {
        _eventType = "Outdoor Gathering";
        _weather = weather;
        _fullDetails = $"{DisplayStandardDetails()} \nEvent Type: Outdoor Gathering\nWeather: {_weather}";
    }
}