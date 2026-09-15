using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using System.Text.Json;
using Lektion03Opgave04.models;

namespace Lektion03Opgave04
{
        public class Program
        {
                static async Task Main(string[] args)
                {
                        HttpClient httpClient = new();
                        CatFactDTO fact = await FetchCatFactAsync(httpClient);
                        Console.WriteLine(fact.fact);
                }
                public static async Task<CatFactDTO> FetchCatFactAsync(HttpClient client)
                {
                        try
                        {
                                CatFactDTO? fact;
                                fact = await client.GetFromJsonAsync<CatFactDTO>("https://catfact.ninja/fact");
                                if(fact != null)
                                {
                                        return fact;
                                }
                                else
                                {
                                        Console.WriteLine("There is no fact here");
                                }
                        }
                        catch (HttpRequestException e)
                        {
                                Console.WriteLine(e.Message);
                        }
                        catch(Exception e)
                        {
                                Console.WriteLine(e.Message);
                        }
                        return null;
                }
        }
}
