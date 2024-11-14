using AccountProvider.Business.Models;

namespace AccountProvider.Business.Factories;

public static class AccountFactory
{
    public static AccountEntity Create(AccountRegistrationForm form)
    {
        try
        {
            return new AccountEntity
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = form.Password
            };
        }
        catch { return null!; }

    }

    public static Account Create(AccountEntity entity)
    {
        try
        {
            return new Account
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };

        }
        catch { return null!; }
    }

    public static IEnumerable<Account> Create(List<AccountEntity> entities)
    {
        var list = new List<Account>();
        try
        {
            foreach (var entity in entities)
            {
                list.Add(new Account
                {
                    Id  = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email
                });
            }
        }
        catch { return null!; }
        return list;
    }

}
