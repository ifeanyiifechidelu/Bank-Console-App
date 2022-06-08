using BankConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    public class EntryPonit
    {
        public static Accounts Entry()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++ WELCOME TO PERCUNIA BANK +++++++++++++++++++++++++++++++++++++++++++++++");
            List<SavingsAccount> savingsAccount = new List<SavingsAccount>();
            List<CurrentAccount> currentAccount = new List<CurrentAccount>();
            var firstName = "";
            var lastName = "";
            var eMailAddress = "";
            var phoneNumber = "";
            decimal initialAmount = 0;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Choose which operation to perform. Type \"options\" or \"help\" t");
                    var entryPoint = Console.ReadLine();
                    if (entryPoint == "options" || entryPoint == "help")
                        break;
                }
                Console.WriteLine("Which account would you like to Open. Type \"1\" for a savings account and \"2\" for current account");
                Options();
                string entryInput = string.Empty;
                while (true)
                {
                    entryInput = Console.ReadLine();
                    Console.Write("What is your First Name?:  ");
                    firstName = Console.ReadLine().Trim().ToUpper();
                    if (ValidateName(firstName))
                        break;
                }
                while (true)
                {
                    Console.Write("What is your Second Name?: ");
                    lastName = Console.ReadLine().Trim().ToUpper();
                    if (ValidateName(lastName))
                        break;
                }
                //Check if the account already exists
                var existingAccount = false;
                if (savingsAccount.Count > 0)
                {
                    if (entryInput == "1")
                    {
                        foreach (var account in savingsAccount)
                        {
                            if (account.AccountName == firstName + " " + lastName)
                                Console.WriteLine("You have an existing savings Account, Would you like to open a Current Account");
                            existingAccount = true;
                        }
                    }
                }
                if (currentAccount.Count > 0)
                {
                    if (entryInput == "2")
                    {
                        foreach (var account in currentAccount)
                        {
                            if (account.AccountName == firstName + " " + lastName)
                                Console.WriteLine("You have an existing Current Account, Would you like to open a Savings Account");
                            existingAccount = true;
                        }
                    }
                }
                if (existingAccount)
                    continue;
                while (true)
                {
                    Console.Write("Enter your email address: ");
                    eMailAddress = Console.ReadLine().Trim();
                    var mail = new MailAddress(eMailAddress);
                    bool isValidEmail = mail.Host.Contains(".");
                    if (isValidEmail)
                        break;
                }
                while (true)
                {
                    Console.Write("Please provide your 11 digit number");
                    phoneNumber = Console.ReadLine().Trim();
                    if (validatePhoneNumber(phoneNumber))
                        break;
                }
                while (true)
                {
                    Console.Write("How much would you like to open the account with");
                    initialAmount = Convert.ToDecimal(Console.ReadLine());
                    if (validAmount(initialAmount))
                        break;
                }
                switch (entryInput)
                {
                    case "1":
                        SavingsAccount savings = new SavingsAccount(initialAmount, DateTime.Now, $"Opened a Savings account with {initialAmount} balance and");
                        savings.AccountType = AccountType.Savings.ToString();
                        savings.email = eMailAddress;
                        savings.Firstname = firstName;
                        savings.Lastname = lastName;
                        savings.phone = phoneNumber;
                        savingsAccount.Add(savings);
                        break;
                    case "2":
                        CurrentAccount currents = new CurrentAccount(initialAmount, DateTime.Now, $"Opened a Savings account with {initialAmount} balance and");
                        currents.AccountType = AccountType.Current.ToString();
                        currents.email = eMailAddress;
                        currents.Firstname = firstName;
                        currents.Lastname = lastName;
                        currents.phone = phoneNumber;
                        currentAccount.Add(currents);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Would you like to open another account opened");
                var decisionString = "";
                while (true)
                {
                    Console.WriteLine("Type \"yes\" OR \"y\" to continue");
                    Console.WriteLine("Type \"no\" OR \"n\" to continue");
                    decisionString = Console.ReadLine().Trim();
                    if (decisionString.Contains("yes") || decisionString.Contains("y"))
                        break;
                    else
                    {
                        break;
                    }
                }
                if (decisionString == "yes" || decisionString == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            Accounts newVal = new Accounts();
            newVal.current = currentAccount;
            newVal.savings = savingsAccount;
            return newVal;
        }
        public static bool validAmount(decimal amount)
        {
            if (amount < 500)
                return false;
            return true;
        }
        private static bool validatePhoneNumber(string number)
        {
            if (number == null || number.Length != 11)
                return false;
            return true;
        }
        private static bool ValidateName(string name)
        {
            var regex = @"^[\p{L} \.\-]+$";
            Regex newRegex = new Regex(regex);
            if (!newRegex.IsMatch(name))
                return false;
            return true;
        }
        private static void Options()
        {
            var options = @"1: Open a Current Account
2: Open a Savings Account";
            Console.WriteLine("Select the operation you would like to carry out \n" + options);
        }
    }
}
