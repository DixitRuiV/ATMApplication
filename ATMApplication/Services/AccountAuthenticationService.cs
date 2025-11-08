using ATMApplication.Customer;
using ATMApplication.Interface;

namespace ATMApplication.Services;

public class AccountAuthenticationService : IAuthenticationService
{
 private readonly Customer.Customer _customer;
 public AccountAuthenticationService(Customer.Customer customer) => _customer = customer;
 public bool Authenticate(string pin) => pin == _customer.Pin;
}
