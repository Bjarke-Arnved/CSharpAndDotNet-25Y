namespace Lektion03Opgave03;

class Lektion03Opgave03Main
{
    static async Task Main(string[] args)
    {
        // TODO: Gør Main asynkron (async Task Main) og kalde UserRepository herfra med await
        StarWarsRepository repos = new();
        Console.WriteLine("Før kald til reposetory");
        var result1 = repos.GetUserByIdAsync(1);
        var result2 = repos.GetUserByIdAsync(2);
        var result3 = repos.GetUserByIdAsync(5);
        Console.WriteLine("Efter kald til reposetory");
        while(!result1.IsCompleted)
        {
                Console.Write(".");
                await Task.Delay(500);
        }
        Task.WaitAll(result1, result2, result3);
        Console.WriteLine(result1.Result);
        Console.WriteLine(result2.Result);
        Console.WriteLine(result3.Result);
        
    }
}
