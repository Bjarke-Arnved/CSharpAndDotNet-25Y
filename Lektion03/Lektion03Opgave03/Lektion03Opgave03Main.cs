namespace Lektion03Opgave03;

class Lektion03Opgave03Main
{
    static async Task Main(string[] args)
    {
        // TODO: Gør Main asynkron (async Task Main) og kalde UserRepository herfra med await
        StarWarsRepository repos = new();

        Console.WriteLine("Før kald til reposetory");
        string result1 = await repos.GetUserByIdAsync(1);
        string result2 = await repos.GetUserByIdAsync(2);
        string result3 = await repos.GetUserByIdAsync(5);
        Console.WriteLine("Efter kald til reposetory");

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
        
    }
}
