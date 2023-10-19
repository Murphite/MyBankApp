using MyBankApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankApp
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public List<Transaction> allTransactions = new List<Transaction>(); // Create a list to store transactions


        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }
}

class Program
{
    static void main(string[] args)
    {
        List<BankAccount> accounts = new List<BankAccount>();

        Console.WriteLine("You are welcome to Intercontinental Bank\'s Online Platform");
        Console.WriteLine("Please enter the number to corresponding number to what you want");

        

        int choice = 0;

        

    }
}




























