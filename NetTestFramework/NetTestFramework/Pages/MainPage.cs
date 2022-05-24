using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class MainPage : BasePage
{
    private const string URI = "/";
    private static readonly By CreateRepositoryButtonBy = By.XPath("(//*[@class='btn btn-sm btn-primary'])[1]");
    private static readonly By ChooseRepositoryButtonBy = By.XPath("(//*[@href='/DimaLayeuskiAQA/NewRepository'])[2]");

    public IWebElement CreateRepositoryButton => WaitService.WaitElementIsExist(CreateRepositoryButtonBy);
    public IWebElement ChooseRepositoryButton => WaitService.WaitElementIsExist(ChooseRepositoryButtonBy);

    public MainPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return CreateRepositoryButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}