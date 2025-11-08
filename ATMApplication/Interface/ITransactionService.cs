using ATMApplication.Customer;

namespace ATMApplication.Interface;

public interface ITransactionService
{
 decimal GetBalance();
 bool Deposit(decimal amount);
 bool Withdraw(decimal amount);
 IReadOnlyList<Transaction> GetTransactions();
}
