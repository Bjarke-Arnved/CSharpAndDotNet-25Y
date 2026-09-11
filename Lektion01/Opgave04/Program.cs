namespace Opgave04
{
        internal class Program
        {
                static void Main(string[] args)
                {
                        Product computer = new("1531", "Computer", 5000, "Hardware");
                        Product computerMus = new("1507", "Computer Mus", 500, "Hardware");
                        var discounted = computerMus with { Price = 399m };
                        Console.WriteLine("Discount:");
                        Console.WriteLine(discounted);
                        Console.WriteLine("Orginal pris:");
                        Console.WriteLine(computerMus);

                        var (id, name, price, category) = computer;
                        Console.WriteLine($"Vare: {name}, Pris: {price}");

                }
        }
}
