using AccountProvider.Business.Factories;
using AccountProvider.Business.Interfaces;
using AccountProvider.Business.Models;
using Moq;

namespace AccountProvider.Tests.Business;

public class Business_Tests
{
    private readonly Mock<IAccountService> _mockAccountService;

    public Business_Tests()
    {
        _mockAccountService = new Mock<IAccountService>();
    }

    [Fact]
    public void CreateAccount__ShouldReturnTrue__WhenAccountIsCreated()
    {
        //Arrange
        
        var accountForm = new AccountRegistrationForm { FirstName = "Björn", LastName = "Åhström", Email = "bjorn.ahstrom@domain.com", Password = "Bjornen123"};
        var account = AccountFactory.Create(accountForm);

        _mockAccountService.Setup(a => a.CreateAccount(It.IsAny<AccountRegistrationForm>())).Returns(new AccountServiceResponse { Success = true, Account = account });

        //Act
        var response = _mockAccountService.Object.CreateAccount(accountForm);

        //Assert
        Assert.True(response.Success);
        Assert.NotNull(response.Account);
        Assert.Equal("Björn", account.FirstName);
        Assert.Equal("Åhström", account.LastName);
        Assert.Equal("bjorn.ahstrom@domain.com", account.Email);
        Assert.Equal("Bjornen123", account.Password);
    }

    [Fact]
    public void CreateAccount__ShouldReturnFalse__WhenAccountIsCreated()
    {
        //Arrange

        var accountForm = new AccountRegistrationForm { FirstName = "Björn", LastName = "Åhström", Email = "bjorn.ahstrom@domain.com", Password = "Bjornen123" };
        var account = AccountFactory.Create(accountForm);

        _mockAccountService.Setup(a => a.CreateAccount(It.IsAny<AccountRegistrationForm>())).Returns(new AccountServiceResponse { Success = false});

        //Act
        var response = _mockAccountService.Object.CreateAccount(accountForm);

        //Assert
        Assert.False(response.Success);
        Assert.Null(response.Account);
        Assert.NotEqual("Bjurn", account.FirstName);
        Assert.NotEqual("Åström", account.LastName);
        Assert.NotEqual("bjorn.ahstrom@domain.se", account.Email);
        Assert.NotEqual("Björne99", account.Password);
    }


    [Fact]
    public void DeleteAccount__ShouldReturnTrue__WhenAccountIsDeleted()
    {
        //Arrange
        var account = new Account {Id = "1", FirstName = "Testarn", LastName = "Testsson", Email = "testarn.testsson@domain.com", AdminPermission = false};
        _mockAccountService.Setup(x => x.DeleteAccount(It.IsAny<string>())).Returns(new AccountServiceResponse { Success = true });

        //Act
        var response = _mockAccountService.Object.DeleteAccount(account.Id);

        //Assert
        Assert.True(response.Success);
        
    }


    [Fact]
    public void DeleteAccount__ShouldReturnFalse__WhenAccountIsDeleted()
    {
        //Arrange
        var account = new Account { Id = "1", FirstName = "Testarn", LastName = "Testsson", Email = "testarn.testsson@domain.com", AdminPermission = false };
        _mockAccountService.Setup(x => x.DeleteAccount(It.IsAny<string>())).Returns(new AccountServiceResponse { Success = false });

        //Act
        var response = _mockAccountService.Object.DeleteAccount("2");

        //Assert
        Assert.False(response.Success);
    }

    [Fact]
    public void UpdateAccount__ShouldReturnTrue__WhenAccountIsUpdated()
    {
        //Arrange
        var account1 = new Account { Id = "1", FirstName = "Testarn", LastName = "Testsson", Email = "testarn.testsson@domain.com", AdminPermission = false };
        var account2 = new Account { Id = "2", FirstName = "Testarn", LastName = "Testsson", Email = "testarn.testsson@domain.com", AdminPermission = false };

        _mockAccountService.Setup(x => x.UpdateAccount(It.IsAny<string>(), account1)).Returns(new AccountServiceResponse { Success = true });

        //Act
        var response = _mockAccountService.Object.UpdateAccount(account1.Id, account1);

        //Assert
        Assert.True(response.Success);

    }
}
