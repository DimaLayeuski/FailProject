using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class SettingPage : BasePage
{
    private const string URI = "/DimaLayeuskiAQA/NewRepository/settings";
    private static readonly By RepositoryNameBy = By.XPath("//*[@name='new_name']");
    private static readonly By RenameButtonBy = By.XPath("//*[@class='flex-self-end btn']");
    private static readonly By DeleteRepositoryButtonBy =
        By.XPath("//summary[contains(text(), 'Delete this repository')]");
    private static readonly By InputBlockBy = By.XPath("(//*[@class='form-control input-block''])[4]");
    private static readonly By ConfirmToDeleteButtonBy = By.XPath("(//button[@class='btn-danger btn btn-block'])[4]");

    public IWebElement FileName => WaitService.WaitElementIsExist(RepositoryNameBy);
    public IWebElement RenameButton => WaitService.WaitElementIsExist(RenameButtonBy);
    public IWebElement DeleteRepositoryButton => WaitService.WaitElementIsExist(DeleteRepositoryButtonBy);
    public IWebElement InputBlock => WaitService.WaitElementIsExist(InputBlockBy);
    public IWebElement ConfirmToDeleteButton => WaitService.WaitElementIsExist(ConfirmToDeleteButtonBy);

    public SettingPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public SettingPage(IWebDriver driver) : base(driver)
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
            return RenameButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}