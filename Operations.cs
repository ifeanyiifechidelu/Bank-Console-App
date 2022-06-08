using BankConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    public class Operations
    {
        public static void MainAccountOperations(List<SavingsAccount> savings, List<CurrentAccount> current)
        {
            var sendersAccountNumber = string.Empty;
            var currentAccountNumber = string.Empty;
            var receiverAccountNumber = string.Empty;
            decimal balance = 0;
            decimal amountTobeSent;
            var accountType = string.Empty;
            var narration = "";
            var receiverType = string.Empty;
            displayOptions();
            while (true)
            {
                var operationsEntry = Console.ReadLine();
                switch (operationsEntry)
                {
                    case "1":
                        Console.Write("Enter your account number: ");
                        sendersAccountNumber = Console.ReadLine();
                        /*Console.WriteLine("How much would you like to deposit");
                        savingsAmount = Convert.ToInt64(Console.ReadLine());*/
                        Console.WriteLine("Select account type \n 1: Current Account \n 2: Savings Account");
                        accountType = Console.ReadLine().Trim();
                        if (accountType == "2")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                    balance = account.Balance;
                            }
                        }
                        if (accountType == "1")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == currentAccountNumber)
                                    balance = account.Balance;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your current account balance is: " + balance);
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.WriteLine("Provide your account number");
                        sendersAccountNumber = Console.ReadLine().Trim();
                        Console.WriteLine("Enter Amount");
                        amountTobeSent = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Select account type \n 1: Saving Account. \n 2: Current Account");
                        accountType = Console.ReadLine();
                        Console.WriteLine("Enter narration or reason for deposit");
                        narration = Console.ReadLine().Trim();

                        if (accountType == "1")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                    account.Deposit(amountTobeSent, DateTime.Now, narration);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Deposit completed");
                        Console.ResetColor();

                        if (accountType == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                    account.Deposit(amountTobeSent, DateTime.Now, narration);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Deposit completed");
                        Console.ResetColor();
                        break;

                    case "3":
                        Console.WriteLine("Provide your account number");
                        sendersAccountNumber = Console.ReadLine().Trim();
                        Console.WriteLine("Enter Amount that you woold like to withdraw");
                        amountTobeSent = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Select account type \n 1: Saving Account. \n 2: Current Account");
                        accountType = Console.ReadLine();
                        Console.WriteLine("Enter narration or reason for Withdrawal");
                        narration = Console.ReadLine().Trim();

                        if (accountType == "1")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                    account.Withdrawal(amountTobeSent, DateTime.Now, narration);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Withdrawal completed");
                        Console.ResetColor();
                        if (accountType == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                    account.Withdrawal(amountTobeSent, DateTime.Now, narration);
                            }
                        }
                        break;

                    case "4":
                        Console.WriteLine("Enter your account number");
                        sendersAccountNumber = Console.ReadLine().Trim();

                        Console.WriteLine("Enter receivers account number");
                        receiverAccountNumber = Console.ReadLine().Trim();

                        Console.WriteLine("Enter amount to be transferred");
                        amountTobeSent = Convert.ToDecimal(Console.ReadLine().Trim());

                        Console.WriteLine("Reason for Transfer");
                        narration = Console.ReadLine().Trim();

                        Console.WriteLine("Select the senders Account; \n 1: Current Account \n 2: Savings Account ");
                        accountType = Console.ReadLine().Trim();

                        Console.WriteLine("Enter receivers Account type \n 1: Current Account \n 2: Savings Account ");
                        receiverType = Console.ReadLine().Trim();

                        SavingsAccount savingsAccount = new SavingsAccount();
                        CurrentAccount currentAccount = new CurrentAccount();
                        if (accountType == "1")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                    currentAccount = account;
                            }
                        }
                        if (accountType == "2")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                    savingsAccount = account;
                            }
                        }
                        if (accountType == "1" && receiverType == "1")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                {
                                    account.Transfer(amountTobeSent, DateTime.Now, narration, currentAccount);
                                }
                            }
                        }
                        if (accountType == "1" && receiverType == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                {
                                    account.Transfer(amountTobeSent, DateTime.Now, narration, savingsAccount);
                                }
                            }
                        }
                        if (accountType == "2" && receiverType == "2")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                {
                                    account.Transfer(amountTobeSent, DateTime.Now, narration, savingsAccount);
                                }
                            }
                        }
                        if (accountType == "2" && receiverType == "1")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == sendersAccountNumber)
                                {
                                    account.Transfer(amountTobeSent, DateTime.Now, narration, currentAccount);
                                }
                            }
                        }
                        break;

                }
                break;
            }
        }

        private static void displayOptions()
        {
            Console.WriteLine("What operation would you like to perform");
            var options = @"Enter  1 to check account Balance
                            Enter 2 to Deposit Fund
                            Enter 3 withdraw Fund
                            Enter 4 to Transfer Fund"
                            ;
            Console.WriteLine(options);
        }

    }
}

