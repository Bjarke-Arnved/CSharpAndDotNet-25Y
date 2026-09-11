using System;
using System.Collections.Generic;
using System.Text;

namespace Opgave03.model
{
        public class BankAccount
        {
                public BankAccount(string accountNumber, string owner, decimal balance)
                {
                        AccountNumber = accountNumber;
                        Owner = owner;
                        Balance = balance;
                }

                public string AccountNumber { get; init; }
                public string Owner { 
                        get;
                        set 
                        {
                                if (value == null || value == "") throw new ArgumentException("Input is null or empty");
                                else field = value;       
                        } 
                }
                public decimal Balance { get; private set; }
                public bool IsOverdrawn { get => Balance < 0; }
                public string FormattedBalance { get => $"Your account balance is: {Balance} DKK"; }
                
                public void Deposit(decimal amount)
                {
                        Balance += amount;
                }
                public void Withdraw(decimal amount)
                {
                        Balance -= amount;
                }
        }
}
