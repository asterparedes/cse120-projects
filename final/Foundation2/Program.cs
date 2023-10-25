using System;

class Program
{
    static void Main(string[] args)
    {
        Address customerAddress = new Address("Lumina Homes", "Bacolod", "Negros Occidental", "Philippines");
        // Address customerAddress = new Address("4228 Lennox Blvd", "Inglewood", "CA", "USA");
        Customer customerName = new Customer("Magdalena Villanueva", customerAddress);
        Product product1 = new Product("Lipstick", 128, 20, 3);
        Product product2 = new Product("Eyeliner", 145, 15, 2);
        

        Order onlineOrder = new Order(customerName);
        onlineOrder.AddProduct(product1);
        onlineOrder.AddProduct(product2);

        Console.WriteLine();
        Console.WriteLine(onlineOrder.PackingLabel());
        Console.WriteLine();
        Console.WriteLine(onlineOrder.ShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: {onlineOrder.TotalPrice()}");
    }
}