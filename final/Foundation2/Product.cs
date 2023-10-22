using System;

public class Product
{
    private string _productName;
    private int _productId;
    private decimal _productPrice;
    private int _productQuantity;

    public Product(string name, int id, decimal price, int quantity)
    {
        _productName = name;
        _productId = id;
        _productPrice = price;
        _productQuantity = quantity;
    }

    public string GetName()
    {
        return _productName;
    }

    public int GetId()
    {
        return _productId;
    }

    public decimal CalculateTotalPrice()
    {
        return _productPrice * _productQuantity;
    }
}