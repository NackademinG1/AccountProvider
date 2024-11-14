namespace AccountProvider.Business.Models;

public class AccountEntity : Account
{
    public string Password { get; set; } = null!;
    public DateTime Created { get; set; }

}
