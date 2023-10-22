using System;

public class Customer
{
    private string _customerName;
    private Address _customerAddress;

    public Customer(string name, Address address)
    {
        _customerName = name;
        _customerAddress = address;
    }

    public string GetName()
    {
        return _customerName;
    }

    public string GetAddress()
    {
        return _customerAddress.GetAddress();
    }

    public bool IsInUSA()
    {
        return _customerAddress.IsInUSA();
    }
}