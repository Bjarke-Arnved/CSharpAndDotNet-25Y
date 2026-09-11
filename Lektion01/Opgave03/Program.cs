using Opgave03.model;

namespace Opgave03
{
        public class Program
        {
                static void Main(string[] args)
                {
                        Console.WriteLine("Testing the Account class");
                        BankAccount randomAccount = new BankAccount("DSGEE325215", "Albus Percival Wulfric Brian Dumbledore", 0);
                        Console.WriteLine("Getting values from properties: ");
                        Console.WriteLine("Account number: " + randomAccount.AccountNumber);
                        Console.WriteLine("Owner: " + randomAccount.Owner);
                        Console.WriteLine("Balance: " + randomAccount.Balance);
                        Console.WriteLine("Is overdrawn: " + randomAccount.IsOverdrawn);
                        Console.WriteLine("Formatted balance: " + randomAccount.FormattedBalance);
                        Console.WriteLine("Methods: ");
                        Console.WriteLine("Depositing 200 DKK");
                        randomAccount.Deposit(200);
                        Console.WriteLine(randomAccount.FormattedBalance);
                        Console.WriteLine("Withdrawing 400 DKK");
                        randomAccount.Withdraw(400);
                        Console.WriteLine(randomAccount.FormattedBalance);
                        Console.WriteLine("Is overdrawn: " + randomAccount.IsOverdrawn);

                }
        }
}
