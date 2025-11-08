using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Account;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account.Account account = new Account.Account();
            account.Name = "John Doe";
            account.Balance = 1000.50m;
            account.AccountNumber = 123456;
            account.BranchNumber = 789;
            Console.WriteLine("Account Holder: " + account.Name);
            Console.WriteLine("Account Balance: $" + account.Balance);
            Console.WriteLine("Account Number: " + account.AccountNumber);
            Console.WriteLine("Branch Number: " + account.BranchNumber);
        }
    }
}
