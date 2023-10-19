using MyBankApp;
using System;
using System.Collections.Generic;

namespace MyBankApp
{
    class Program
    {

        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
             
            Console.WriteLine("Welcome To Plantinum City Bank\'s Online Platform\n");
            Console.WriteLine("Please choose an option by entering the corresponding number: \n");

            while (true)
            {
                Console.WriteLine("Press 1 to create a new account\n");
                Console.WriteLine("Press 2 to access an existing account\n");
                Console.WriteLine("Press 3 to exit\n");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount(accounts);
                        break;

                    case 2:
                        AccessExistingAccount(accounts);
                        break;

                    case 3:
                        Console.WriteLine("Thank you for using Plantinum City Bank. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        static int acctNumberSeed = 1020210000; // Declare this variable outside of any method 

        static void CreateAccount(List<BankAccount> accounts)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            // Generate a unique account number
            string accountNumber = GenerateAccountNumber();

            decimal initialBalance = 0.0m; // You can set an initial balance here.

            BankAccount newAccount = new BankAccount(name, initialBalance, accountNumber);
            accounts.Add(newAccount);

            Console.WriteLine($"Account created successfully! Your account number is: {accountNumber}");
        }

       
        static string GenerateAccountNumber()
        {
            // Implement logic to generate a unique account number here
            acctNumberSeed++; // Increment the seed for each new account
            return acctNumberSeed.ToString();
        }


        static void AccessExistingAccount(List<BankAccount> accounts)
        {
            Console.Write("Enter your account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount existingAccount = accounts.Find(account => account.Number == accountNumber);

            if (existingAccount != null)
            {
                 Console.WriteLine($"Welcome back, {existingAccount.Owner}!");

                while (true)
                {
                    Console.WriteLine("Press 1 to check account balance");
                    Console.WriteLine("Press 2 to get account history");
                    Console.WriteLine("Press 3 to make a deposit");
                    Console.WriteLine("Press 4 to make a withdrawal");
                    Console.WriteLine("Press 5 to exit");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Account Balance: {existingAccount.AccountBalance:C}");
                            break;

                        case 2:
                            Console.WriteLine("Account History:");
                            string history = existingAccount.GetAccountHistory();
                            Console.WriteLine(history);
                            break;

                        case 3:
                            Console.Write("Enter the deposit amount: ");
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Enter description: ");
                            string description  = Console.ReadLine();

                            existingAccount.MakeDeposit(depositAmount, DateTime.Now, description);
                            Console.WriteLine($"Successfully deposited {depositAmount:C} for {description}");
                            break;

                        case 4:
                            Console.Write("Enter the withdrawal amount: ");
                            decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Enter description: ");
                            string note = Console.ReadLine();
                            
                            try
                            {
                                existingAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, note);
                                Console.WriteLine($"Successfully withdrew {withdrawalAmount:C} for {note}");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Thank you for using Platinum City Bank. Goodbye!");
                            Environment.Exit(0); // Exit the application
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found. Please enter a valid account number.");
            }




        }
    }
}
