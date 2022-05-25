using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class LoginPage : BasePage
{
    private const string URI = "/login";
    private static readonly By UsernameInputBy = By.XPath("//div//input[@id='login_field']");
    private static readonly By PasswordInputBy = By.XPath("//*[@id='password']");
    private static readonly By LoginButtonBy = By.XPath("(//*[@class='btn btn-primary btn-block js-sign-in-button'])");

    public IWebElement UsernameInput => WaitService.WaitElementIsExist(UsernameInputBy);
    public IWebElement PasswordInput => WaitService.WaitElementIsExist(PasswordInputBy);
    public IWebElement LoginButton => WaitService.WaitElementIsExist(LoginButtonBy);

    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + URI);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return LoginButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}