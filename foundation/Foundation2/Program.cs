using System;

class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("Alice", address1);
        Customer customer2 = new Customer("Bob", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "W001", 10.00, 2));  // Total: $20.00
        order1.AddProduct(new Product("Gadget", "G002", 15.50, 1));  // Total: $15.50

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Thingamajig", "T003", 20.00, 3));  // Total: $60.00
        order2.AddProduct(new Product("Doodad", "D004", 12.50, 2));       // Total: $25.00

        // Display order details for Order 1
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():0.00}\n");

        // Display order details for Order 2
        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():0.00}");
    }
}
