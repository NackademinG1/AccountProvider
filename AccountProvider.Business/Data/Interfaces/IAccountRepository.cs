using AccountProvider.Business.Data.Models;
using AccountProvider.Business.Models;

namespace AccountProvider.Business.Data.Interfaces;

public interface IAccountRepository
{
    public RepositoryResponse Add(AccountEntity accountEntity);

    public AccountEntity Get(string id);

    public IEnumerable<AccountEntity> GetAll();


}
