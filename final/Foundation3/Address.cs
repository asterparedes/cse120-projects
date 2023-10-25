using System;

public class Address 
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private int _zipCode;
    private string _country;

    public Address(string street, string city, string state, int zipCode, string country)
    {
        _streetAddress = street;
        _city = city;
        _state = state;
        _zipCode = zipCode;
        _country = country;
    }

    public string GetAddress()
    {
        return $"{_streetAddress}, {_city}, {_state}, {_country}";
    }
}