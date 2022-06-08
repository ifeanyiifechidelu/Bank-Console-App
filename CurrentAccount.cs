using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Services
{
    public class CurrentAccount : CustomerDetails
    {
        private decimal initialAmount;
        private DateTime now;
        private string v;

        public CurrentAccount(decimal initialAmount, DateTime now, string v)
        {
            this.initialAmount = initialAmount;
            this.now = now;
            this.v = v;
        }

        public decimal Balance { get; set; }
        public string AccountName { get; internal set; }

        //{ get; set; }
        public CurrentAccount()
        {

        }

        /*public SavingsAccount(decimal initiaalBalance)
        {
            if (initiaalBalance < defaultBalance)
            {
                throw new ArgumentOutOfRangeException(nameof(initiaalBalance), "The balance is below the default amount required for Savings account");
            }
            var deposit = new Transactions(initiaalBalance, DateTime.Now, );
        }*/

        //validate the deposit
        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (amount < 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to be deposited has to be more than N1000");
                //return false;
            }

            var deposit = new Transactions(amount, DateTime.Now, note);
            totalTransaction.Add(deposit);
            /*this.Balance += amount;*/
            //return true;
        }

        //validate the withdrawal
        public void Withdrawal(decimal amount, DateTime date, string note)
        {
            if (Balance - amount <= 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Insufficient balance");
            }
            if (amount < 1000)
            {
                throw new InvalidOperationException("Withdrawal amount has to be more than 1000");
            }
            var withdrawal = new Transactions(amount, DateTime.Now, note);
            totalTransaction.Add(withdrawal);

            //return true;
        }

        public void Transfer(decimal amount, DateTime date, string note, CurrentAccount account)
        {
            if (amount < 500)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to be transfered has to be greater than N500");
            }
            if (Balance - amount <= 0)
            {
                throw new InvalidOperationException("Insuffucent fund");
            }
            var savingsTransaction = new Transactions(-amount, date, note);
            var currentTransaction = new Transactions(amount, date, note);
            totalTransaction.Add(savingsTransaction);
            account.totalTransaction.Add(currentTransaction);
        }
        public void Transfer(decimal amount, DateTime date, string note, SavingsAccount account)
        {
            if (amount < 500)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to be transfered has to be greater than 500");
            }
            if (Balance - amount <= 0)
            {
                throw new InvalidOperationException("Insuffucent fund");
            }
            var savingsTransaction = new Transactions(-amount, date, note);
            var currentTransaction = new Transactions(amount, date, note);
            totalTransaction.Add(savingsTransaction);
            account.totalTransaction.Add(currentTransaction);
        }
    }
}
