using BankConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    public class CustomerDetails
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string AmountBal { get; set; }
        public List<Transactions> totalTransaction = new List<Transactions>();
    }

    public class AccountNumberGenerator
    {
        //Account Numbers are generated here
        public string NumberGenerator(int length)
        {
            Random generatedAcct = new Random();

            string accountNumgenerated = string.Empty;


            for (int i = 0; i < 1; i++)
            {
                accountNumgenerated = generatedAcct.Next().ToString();
            }

            return accountNumgenerated;

        }

    }

}
