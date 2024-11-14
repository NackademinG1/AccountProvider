using AccountProvider.Business.Models;

namespace AccountProvider.Business.Interfaces;

public interface IAccountService
{
    public AccountServiceResponse CreateAccount(AccountRegistrationForm accountRegistrationForm);
    public AccountServiceResponse GetAccount(string Id);
    public AccountServiceResponse GetAllAccounts();
    public AccountServiceResponse UpdateAccount(string Id, Account account);
    public AccountServiceResponse DeleteAccount(string Id);
}
