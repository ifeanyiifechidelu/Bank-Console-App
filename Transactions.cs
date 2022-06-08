using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Services
{
    public class Transactions
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public Transactions(decimal amount, DateTime date, string details)
        {
            this.Amount = amount;
            this.Date = date;
            this.Details = details;
        }
    }
}
