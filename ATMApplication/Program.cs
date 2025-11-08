using System;
using ATMApplication.Customer;
using ATMApplication.Interface;
using ATMApplication.Services;

Customer customer = new Customer
{
    Name = "John Doe",
    AccountNumber = "123456789",
    Balance =1000.00m
};
IAuthenticationService authService = new AccountAuthenticationService(customer);
ITransactionService txService = new AccountTransactionService(customer);

Console.WriteLine("Welcome to the ATM Application");
int attempts =0;
const int maxAttempts =3;
while (attempts < maxAttempts)
{
    Console.Write("Enter PIN: ");
    var pin = Console.ReadLine();
    if (authService.Authenticate(pin!))
    {
        Console.WriteLine($"Hello, {customer.Name}!\n");
        RunMenu(txService, customer);
        return;
    }
    attempts++;
    Console.WriteLine("Invalid PIN." + (attempts < maxAttempts ? " Try again." : ""));
}
Console.WriteLine("Too many failed attempts. Card retained.");
return;

static void RunMenu(ITransactionService txService, Customer customer)
{
    while (true)
    {
        Console.WriteLine("============================");
        Console.WriteLine("1. View Balance");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Transaction History");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine($"Current balance: {txService.GetBalance():C}");
                break;
            case "2":
                Console.Write("Enter amount to deposit: ");
                if (TryReadAmount(out var dep))
                {
                    if (txService.Deposit(dep)) Console.WriteLine($"Deposited {dep:C}. New balance: {txService.GetBalance():C}");
                    else Console.WriteLine("Deposit failed. Amount must be positive.");
                }
                break;
            case "3":
                Console.Write("Enter amount to withdraw: ");
                if (TryReadAmount(out var wd))
                {
                    if (txService.Withdraw(wd)) Console.WriteLine($"Withdrawn {wd:C}. New balance: {txService.GetBalance():C}");
                    else Console.WriteLine("Withdrawal failed. Check amount and balance.");
                }
                break;
            case "4":
                var txs = txService.GetTransactions();
                if (txs.Count ==0) Console.WriteLine("No transactions yet.");
                else
                {
                    Console.WriteLine("Recent Transactions:");
                    foreach (var t in txs) Console.WriteLine(t);
                }
                break;
            case "5":
                Console.WriteLine("Thank you for using the ATM Application!");
                return;
            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
    }
}

static bool TryReadAmount(out decimal amount)
{
    var raw = Console.ReadLine();
    if (decimal.TryParse(raw, out amount) && amount >0) return true;
    Console.WriteLine("Invalid amount.");
    return false;
}
