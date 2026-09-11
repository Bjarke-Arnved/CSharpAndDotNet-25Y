using Opgave05.model;

namespace Opgave05
{
        internal class Program
        {
                static void Main(string[] args)
                {
                        var c1 = new GeoPointClass { Latitude = 56.15, Longitude = 10.20 };
                        var c2 = new GeoPointClass { Latitude = 56.15, Longitude = 10.20 };

                        var r1 = new GeoPointRecord(56.15, 10.20);
                        var r2 = new GeoPointRecord(56.15, 10.20);

                        // Both equate to false for some reason
                        Console.WriteLine(ReferenceEquals(c1, c2));
                        Console.WriteLine(ReferenceEquals(r1, r2));

                        Console.WriteLine();

                        // Writes out the name of the object type
                        Console.WriteLine(c1.ToString());
                        Console.WriteLine(r1.ToString());


                }
        }
}
