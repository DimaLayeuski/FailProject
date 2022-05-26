using Allure.Commons;
using FluentAssertions;
using NetTestFramework.Pages;
using NetTestFramework.Services;
using NetTestFramework.Steps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace NetTestFramework.Tests.Ui;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureEpic("Authorization-UI")]
[AllureSeverity(SeverityLevel.blocker)]
[Category("Authorization-UI")]
public class AuthorizationTests : BaseTest
{
    private HomePage _homePage = null!;
    private LoginPage _loginPage = null!;
    private MainPage _mainPage = null!;


    [SetUp]
    public void InstantiateRequiredPages()
    {
        _homePage = new HomePage(_driver);
        _loginPage = new LoginPage(_driver);
        _mainPage = new MainPage(_driver);
    }

    [Test]
    [Category("Positive")]
    [AllureSuite("Authorization-UI")]
    [AllureStep("Authorize using valid data")]
    public void Authorization_WithValidData_MainPageOpened()
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        _mainPage.PageOpened.Should().BeTrue();
    }
}