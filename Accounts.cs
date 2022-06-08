using BankConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    public class Accounts
    {
        //
        public List<CurrentAccount> current = new List<CurrentAccount>();
        public List<SavingsAccount> savings = new List<SavingsAccount>();

    }
}
