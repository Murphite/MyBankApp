using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyBankApp
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }

        public List<Transaction> allTransactions = new List<Transaction>(); // Create a list to store transactions

        public decimal AccountBalance
        {
            get
            {
                decimal acctBalance = 1000;
                foreach (var transaction in allTransactions)
                {
                    acctBalance += transaction.Amount;
                }
                return acctBalance;
            }
        }

// public static int acctNumberSeed = 1020217935;

        public BankAccount(string name, decimal initialBalance, string accountNumber)
        {
            Number = GenerateAccountNumber();
            Owner = name;
            //MakeDeposit(decimal amount, DateTime date);
        }

        public string GenerateAccountNumber()
        {
            int acctNumberSeed = 1020210000;
            // Implement logic to generate a unique account number here
            acctNumberSeed++; // Increment the seed for each new account
            return acctNumberSeed.ToString();
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of initial deposit must be positive");
            }

            var initialDeposit = new Transaction(amount, DateTime.Now, note );
            allTransactions.Add(initialDeposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (AccountBalance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }


        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            decimal balance = 0;

            report.AppendLine("Date\t\tAmount\tBalance\tNote");

            foreach (var transaction in allTransactions)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Notes}");
            } 

            return report.ToString();
        }
                

    }
}