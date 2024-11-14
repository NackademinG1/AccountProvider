using AccountProvider.Business.Models;
using System.Text.RegularExpressions;

namespace AccountProvider.Business.Services;

public class AccountValidator
{
    public AccountValidatorResponse Validate(AccountRegistrationForm accountRegistrationForm)
    {
        if (string.IsNullOrEmpty(accountRegistrationForm.Password) && string.IsNullOrEmpty(accountRegistrationForm.FirstName) && string.IsNullOrEmpty(accountRegistrationForm.LastName) && string.IsNullOrEmpty(accountRegistrationForm.Email))
        {
            var Response = IsValidEmail(accountRegistrationForm.Email);
            if (Response)
            {
                return new AccountValidatorResponse
                {
                    Success = true,
                    AccountRegistrationForm = accountRegistrationForm

                };
            }
            else
            {
                return new AccountValidatorResponse
                {
                    Success = false
                };
            }
        }
        else
        {
            return new AccountValidatorResponse
            {
                Success = false
            };
        }
    }

    private bool IsValidEmail(string email)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }


}
