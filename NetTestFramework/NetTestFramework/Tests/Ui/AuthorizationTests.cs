using NetTestFramework.Services;
using NetTestFramework.Steps;
using NUnit.Framework;

namespace NetTestFramework.Tests.Ui;

public class AuthorizationTests : BaseTest
{
    [Test]
    public void Authorization_WithValidData_MainPageOpened()
    {
        LoginStep loginStep = new LoginStep(_driver);
        loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
    }
}