namespace Lektion03Opgave01;

public class Lektion03Opgave01Main
{
    public delegate double MathOperation(double x, double y);
    public static void Main(string[] args)
    {
        ExecuteAndPrint(5, 6, Add);
        ExecuteAndPrint(5, 6, Subtract);
        ExecuteAndPrint(5, 6, Multiply);
        ExecuteAndPrint(50, 6, (x, y) => x / y);
        ExecuteAndPrint(5, 6, (x, y) => Math.Pow(x, y));



    }
    public static double Add(double x, double y)
    {
        return x + y;
    }
    public static double Subtract(double x, double y)
    {
        return x - y;
    }
    public static double Multiply(double x, double y)
    {
        return x * y;
    }
    public static void ExecuteAndPrint(double x, double y, MathOperation operation)
    {
        Console.WriteLine(operation(x, y));
    }
}