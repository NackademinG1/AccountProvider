using AccountProvider.Business.Data.Interfaces;
using AccountProvider.Business.Factories;
using AccountProvider.Business.Interfaces;
using AccountProvider.Business.Models;

namespace AccountProvider.Business.Services;

public class AccountService(IAccountRepository? accountRepository) : IAccountService
{
    private List<AccountEntity> _accountEntities = [];
    private readonly IAccountRepository? _accountRepository = accountRepository;

    public AccountServiceResponse CreateAccount(AccountRegistrationForm accountRegistrationForm)
    {
        var accountValidator = new AccountValidator();
        var validatorResponse = accountValidator.Validate(accountRegistrationForm);
        if (validatorResponse.Success)
        {
            var accountEntity = AccountFactory.Create(validatorResponse.AccountRegistrationForm!);

            if (accountEntity != null)
            {
                _accountRepository!.Add(accountEntity);

                //Behövs detta när vi sparar i databasen?
                var account = AccountFactory.Create(accountEntity);

                if (account != null)
                {
                    return new AccountServiceResponse
                    {
                        Success = true,
                        Account = account
                    };
                }
                else
                {
                    return new AccountServiceResponse { Success = false, Account = null };
                }
            }
            else
            {
                return new AccountServiceResponse { Success = false, Account = null };
            }
        }
        else
        {
            return new AccountServiceResponse { Success = false, Account = null };
        }
    }

    public AccountServiceResponse GetAccount(string Id)
    {
        try
        {
            var existingAccount = _accountEntities.FirstOrDefault(y => y.Id == Id);

            if (existingAccount != null)
            {
                return new AccountServiceResponse { Success = true, Account = existingAccount };
            }

            else
            {
                return new AccountServiceResponse { Success = false, Message = "Something went wrong when getting account" };
            }
        }
        catch (Exception ex)
        {
            return new AccountServiceResponse { Success = false, Message = ex.Message };
        }

    }

    public AccountServiceResponse GetAllAccounts()
    {
        List<Account> accounts = [];

        try
        {
            var entities = _accountRepository!.GetAll();

            if (entities.Count() > 0)
            {
                _accountEntities.Clear();
                _accountEntities = entities.ToList();
                foreach (var entity in _accountEntities)
                {
                    var account = AccountFactory.Create(entity);
                    accounts.Add(account);

                }
                return new AccountServiceResponse
                {
                    Success = true,
                    Accounts = accounts
                };
            }
            else
            {
                return new AccountServiceResponse { Success = false, Message = "Something went wrong when getting all accounts" };
            }

        }
        catch (Exception ex)
        {
            return new AccountServiceResponse { Success = false, Message = ex.Message };
        }
    }



    public AccountServiceResponse UpdateAccount(string Id, Account account)
    {
        try
        {
            GetAllAccounts();

            var existingAccount = _accountEntities.FirstOrDefault(x => x.Id == Id);

            if (existingAccount != null)
            {
                existingAccount.FirstName = account.FirstName;
                existingAccount.LastName = account.LastName;
                existingAccount.Email = account.Email;


                var response = _accountRepository!.Add(existingAccount);

                if (response.Success) 
                {
                    return new AccountServiceResponse
                    {
                        Success = true,
                        Message = response.Message
                    };
                }
                else
                {
                    return new AccountServiceResponse { Success = false, Message = response.Message };
                }

            }
            else
            {
                return new AccountServiceResponse { Success = false };

            }
        }
        catch (Exception ex)
        {
            return new AccountServiceResponse { Success = false, Message = ex.Message };
        }
    }

    public AccountServiceResponse DeleteAccount(string Id)
    {
        try
        {
            GetAllAccounts();
            var existingAccount = _accountEntities.FirstOrDefault(x => x.Id == Id);

            if (existingAccount != null)
            {
                _accountEntities.Remove(existingAccount);
                //Hur tar vi bort från databasen?
                return new AccountServiceResponse
                {
                    Success = true
                };
            }
            else
            {
                return new AccountServiceResponse { Success = false, Message = "Something went wrong when deleting account" };
            }

        }
        catch (Exception ex)
        {
            return new AccountServiceResponse { Success = false, Message = ex.Message };
        }


    }
}


// RAD 166 & 25