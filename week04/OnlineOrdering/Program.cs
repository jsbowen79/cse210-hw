using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Address jaddress = new Address("11767 idalia Street", "Commerce City", "CO", "Bolivia");
        Address paddress = new Address("14925 Phillips Circle", "Ogden", "Utah", "UsA");
        Customer customer1 = new Customer("Joseph Bowen", jaddress);
        Customer customer2 = new Customer("Purity Bowen", paddress);


        Product product1 = new Product("Vernal Executive Desk", 12, 1500, 2);
        Product product2 = new Product("Kibbles and Bits Dog Food", 3, 7.99, 3);
        Product product3 = new Product("Milk", 1, 2.97, 4);
        Product product4 = new Product("Ford F350 Longbed", 350, 92000, 1);
        Product product5 = new Product("Apple Watch", 8, 395.99, 1);
        Product product6 = new Product("Iphone 16 Pro Max", 19, 1599.99, 2);


        List<Product> jorderProds = new List<Product>();
        List<Product> porderProds = new List<Product>();

        jorderProds.Add(product4);
        jorderProds.Add(product5);
        jorderProds.Add(product6);
        porderProds.Add(product1);
        porderProds.Add(product2);
        porderProds.Add(product3);

        Order jorder = new Order(jorderProds, customer1);
        Order porder = new Order(porderProds, customer2);


        Console.WriteLine(jorder.GeneratePackingLabel().ToString());
        Console.WriteLine(jorder.GenerateShippingLabel().ToString());
        Console.WriteLine($"The total of your order is ${jorder.CalculateOrderTotal()}");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(porder.GeneratePackingLabel().ToString());
        Console.WriteLine(porder.GenerateShippingLabel().ToString());
        Console.WriteLine($"The total of your order is ${porder.CalculateOrderTotal()}");

        Console.WriteLine();
        Console.WriteLine();



    }
}