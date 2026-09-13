using System.Globalization;
using System.Reflection;
using Opgave02.model;

namespace Opgave02;

class Program
{
    static void Main(string[] args)
    {
        var products = SeedData.Products;
        var customers = SeedData.Customers;
        // 1. Find alle produkter i kategorien Category.Elektronik, som er på lager (StockCount > 0)
                products.Where(p => p.StockCount > 0).ToList().ForEach(p => Console.WriteLine($"{p.StockCount} {p.Name}'(s) are in stock"));
                Console.WriteLine();
                Console.WriteLine();
        // 2. Udskriv navn og pris for disse produkter, sorteret efter pris i faldende rækkefølge (dyreste først)
                products.Where(p => p.StockCount > 0).OrderByDescending(p => p.Price).ToList().ForEach(p => Console.WriteLine($"{p.Name} only {p.Price} DKK, in stock!"));
                Console.WriteLine();
                Console.WriteLine();
                // 3. Find alle kunder fra byen "Aarhus" og udskriv deres navne
                customers.Where(c => c.City.Equals("Aarhus")).ToList().ForEach(c => Console.WriteLine(c.Name + " " + c.City));
                Console.WriteLine();

                // 4. Bonus Find de 3 mest solgte produkter målt på samlet solgt antal.
                customers
                        .SelectMany(c => c.Orders)
                        .SelectMany(o => o.Items)
                        .GroupBy(o => o.Product.Name)
                        .Select( g => new
                        {
                                Name = g.Key,
                                Quantity = g.Sum(s => s.Quantity)
                        }
                        )
                        .OrderByDescending(g => g.Quantity)
                        .Take(3)
                        .ToList()
                        .ForEach(i => Console.WriteLine(i.Name + " " + i.Quantity));
                Console.WriteLine();
                //5. * *Bonus:**Lav en opgørelse over alle kunder og deres samlede købsbeløb i shoppen.
                customers
                        .Select(c => new
                        {
                                Name = c.Name,
                                OrderCount = c.Orders.Count,
                                TotalSpent = c.Orders
                                .SelectMany(o => o.Items)
                                .Sum(i => i.Product.Price * i.Quantity)
                        }
                        )
                        .DefaultIfEmpty()
                        .OrderByDescending(c => c.TotalSpent)
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Name + " Antal ordre: " + c.OrderCount + " Samlede beløb: " + c.TotalSpent));
        }
}
