namespace ATMApplication.Interface;

public interface IAuthenticationService
{
 bool Authenticate(string pin);
}
