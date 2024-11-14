namespace AccountProvider.Business.Models;

public class AccountServiceResponse : BaseResponse
{
    public Account? Account { get; set; }

    public List<Account>? Accounts { get; set; }

}
