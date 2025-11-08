Project: ATMApplication
Description: A simple console-based ATM simulation built with .NET 8 and C# 12. It demonstrates separation of concerns via interfaces and services for authentication and transactions, plus a basic transaction history model.
Key Features:
•	PIN authentication (IAuthenticationService, AccountAuthenticationService)
•	Deposit and withdrawal operations (ITransactionService, AccountTransactionService)
•	Immutable transaction history (list of Transaction)
•	Input validation and retry logic
•	Clean separation between domain model (Customer, Transaction) and services
Architecture:
•	Domain: Customer, Transaction, TransactionType
•	Interfaces: IAuthenticationService, ITransactionService
•	Services: AccountAuthenticationService, AccountTransactionService
•	Entry point: Program (menu loop, dependency usage)
Getting Started:
1.	Prerequisites: .NET 8 SDK installed
2.	Clone: git clone <repo-url> cd ATMApplication
3.	Build: dotnet build
4.	Run: dotnet run
5.	Default demo PIN: 1234
Usage Flow:
•	Enter PIN (3 attempts)
•	Use menu: View Balance / Deposit / Withdraw / Transaction History / Exit
•	Transactions are timestamped (UTC) and show post-operation balance
Extensibility Ideas:
•	Multiple customers + repository
•	Persist transactions (file / database)
•	Dependency injection (e.g., Microsoft.Extensions.DependencyInjection)
•	Logging (Serilog)
•	Unit tests (xUnit) for services
•	Daily withdrawal limits / overdraft rules
•	Async I/O and cancellation
Example Enhancement Path:
•	Add ICustomerRepository
•	Introduce DI container
•	Replace in-memory state with persistence
•	Wrap menu in a loop with error handling abstraction
Folder Overview (logical):
•	Interface/ service contracts
•	Services/ implementations
•	Controller/ domain models (could be renamed to Domain/)
•	Program.cs application bootstrap
License: Add a LICENSE file (MIT recommended for simplicity).
Contributing: Open issues, fork, submit PRs. Keep changes small and tested.
