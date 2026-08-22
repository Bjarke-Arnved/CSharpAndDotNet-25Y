using System.Text.Json;
using Opgave01.model;

namespace Opgave01;

class Program
{
    static void Main(string[] args)
    {
        // Opgave 1.1: Serialiser et enkelt Item-objekt til JSON
        Item item = GetItem();
                // TODO: Serialiser 'item' til en JSON-streng og udskriv den til konsollen
                Console.WriteLine(JsonSerializer.Serialize(item));


                // Opgave 1.2: Serialiser et Order-objekt til JSON med pæn formatering (WriteIndented)
                Order order = GetOrder();
                // TODO: Serialiser 'order' til en JSON-streng med WriteIndented = true og udskriv den til konsollen
                JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true};
                Console.WriteLine(JsonSerializer.Serialize(order, options));

        // Opgave 1.3: Serialiser en liste af ordrer (List<Order>) til JSON
        List<Order> orders = GetOrders();
                // TODO: Serialiser 'orders' til en JSON-streng og udskriv den til konsollen
                Console.WriteLine(JsonSerializer.Serialize(orders, options).ToString());
    }

    public static Item GetItem()
    {
        return new Item("Kaffe", 25.50m);
    }

    public static Order GetOrder()
    {
        return new Order(new List<OrderLine>
        {
            new OrderLine(new Item("Kaffe", 25.50m), 2),
            new OrderLine(new Item("Kanelsnegl", 18.00m), 3),
            new OrderLine(new Item("Juice", 22.00m), 1)
        });
    }

    public static List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order(new List<OrderLine>
            {
                new OrderLine(new Item("Espresso", 20.00m), 1),
                new OrderLine(new Item("Croissant", 15.00m), 2)
            }),
            new Order(new List<OrderLine>
            {
                new OrderLine(new Item("Sandwich", 45.00m), 2),
                new OrderLine(new Item("Sodavand", 25.00m), 2)
            })
        };
    }
}

