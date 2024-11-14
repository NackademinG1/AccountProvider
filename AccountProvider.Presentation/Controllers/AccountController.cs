using AccountProvider.Business.Interfaces;
using AccountProvider.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountProvider.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount(AccountRegistrationForm accountRegistrationForm)
        {
            var response = _accountService.CreateAccount(accountRegistrationForm);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            if (response.Account == null)
            {
                return BadRequest(response.Message);
            }

            return CreatedAtAction(nameof(GetAccount), new { id = response.Account.Id }, response.Account);
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(string id)
        {
            var response = _accountService.GetAccount(id);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Account);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts() 
        { 
            var response = _accountService.GetAllAccounts();
            if (!response.Success)
            {
                return StatusCode(500, response.Message);
            }
            return Ok(response.Accounts);
        }



    }

}
