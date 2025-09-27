using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System\n");

        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "Ontario", "Canada");
        Address address3 = new Address("789 Pine Rd", "Los Angeles", "CA", "USA");

        // Create customers
        Customer customer1 = new Customer("Noah Smith", address1);
        Customer customer2 = new Customer(" Emma Williams", address2);
        Customer customer3 = new Customer("James Milner", address3);

        // Create products
        Product product1 = new Product("Laptop", "LAP1001", 899.99, 1);
        Product product2 = new Product("Wireless Mouse", "MOU2002", 29.99, 2);
        Product product3 = new Product("USB-C Cable", "CAB3003", 19.99, 3);
        Product product4 = new Product("Monitor", "MON4004", 249.99, 1);
        Product product5 = new Product("Keyboard", "KEY5005", 79.99, 1);
        Product product6 = new Product("Webcam", "WEB6006", 49.99, 2);

        // Create Order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create Order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        // Create Order 3
        Order order3 = new Order(customer3);
        order3.AddProduct(product2);
        order3.AddProduct(product4);
        order3.AddProduct(product6);

        // Display order information
        DisplayOrder(order1, 1);
        DisplayOrder(order2, 2);
        DisplayOrder(order3, 3);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"=== ORDER #{orderNumber} ===");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
        Console.WriteLine("=============================\n");
    }
}