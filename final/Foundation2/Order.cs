using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;
    private const decimal _USAShippingFee = 5;
    private const decimal _InternationalShippingFee = 35;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal TotalPrice()
    {
        decimal total = 0;
        foreach(Product product in _products)
        {
            total += product.CalculateTotalPrice();
        }

        if (_customer.IsInUSA())
        {
            total += _USAShippingFee;
        }
        else
        {
            total += _InternationalShippingFee;
        }

        return total;
    }

    public string PackingLabel()
    { 
        string label = "Packing Label \n";
        if (_products.Count > 0)
        {
            label += $"Product Name: {_products[0].GetName()}\nProduct Id: {_products[0].GetId()}";

            for(int i = 1; i < _products.Count; ++i)
            {
                label += $"\n\nProduct Name: {_products[i].GetName()}\nProduct Id: {_products[i].GetId()}";
            }
        }
        return label;
    }

    public string ShippingLabel()
    {
        string label = "Shipping Label \n";

        label += $"Customer Name: {_customer.GetName()}\nAddress {_customer.GetAddress()}";
        
        return label;
    }
}