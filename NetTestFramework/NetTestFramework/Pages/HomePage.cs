using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class HomePage : BasePage
{
    private const string URI = "/";
    private static readonly By SignInBy = By.XPath("//div/*[@href='/login']");

    public IWebElement SignIn => WaitService.WaitElementIsExist(SignInBy);

    public HomePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public HomePage(IWebDriver driver) : base(driver)
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
            return SignIn.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}