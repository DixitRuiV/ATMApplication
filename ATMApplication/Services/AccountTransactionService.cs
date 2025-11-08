using ATMApplication.Customer;
using ATMApplication.Interface;

namespace ATMApplication.Services;

public class AccountTransactionService : ITransactionService
{
 private readonly Customer.Customer _customer;
 public AccountTransactionService(Customer.Customer customer) => _customer = customer;
 public decimal GetBalance() => _customer.Balance;
 public bool Deposit(decimal amount)
 {
 if (amount <=0) return false;
 _customer.Balance += amount;
 _customer.Transactions.Add(new Transaction
 {
 Type = TransactionType.Deposit,
 Amount = amount,
 PostBalance = _customer.Balance
 });
 return true;
 }
 public bool Withdraw(decimal amount)
 {
 if (amount <=0 || amount > _customer.Balance) return false;
 _customer.Balance -= amount;
 _customer.Transactions.Add(new Transaction
 {
 Type = TransactionType.Withdrawal,
 Amount = amount,
 PostBalance = _customer.Balance
 });
 return true;
 }
 public IReadOnlyList<Transaction> GetTransactions() => _customer.Transactions;
}
