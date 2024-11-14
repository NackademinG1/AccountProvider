using System.ComponentModel.DataAnnotations;

namespace AccountProvider.Business.Models;

public class AccountRegistrationForm
{
    [Required(ErrorMessage = "You must enter a first name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a last name")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter an email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid password")]
    public string Password { get; set; } = null!;

}
