using AccountProvider.Business.Data.Interfaces;
using AccountProvider.Business.Data.Models;
using AccountProvider.Business.Models;

namespace AccountProvider.Business.Data.Repositories;

public class AccountsRepository : IAccountRepository
{
    public RepositoryResponse Add(AccountEntity accountEntity)
    {
        throw new NotImplementedException();
    }

    public AccountEntity Get(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AccountEntity> GetAll()
    {
        throw new NotImplementedException();
    }
}
