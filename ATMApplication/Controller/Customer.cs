using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Customer
{
    public class Customer
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
        public string Pin { get; set; } = "1234"; // default demo PIN
        public List<Transaction> Transactions { get; } = new();
    }

    public class Transaction
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public decimal PostBalance { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public override string ToString() => $"[{Timestamp:O}] {Type} {Amount:C} -> Balance {PostBalance:C}";
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}
