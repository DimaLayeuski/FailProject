using System;
using NetTestFramework.Pages;
using OpenQA.Selenium;

namespace NetTestFramework.Steps;

public class BaseStep
{
    private IWebDriver _driver;
    protected AddFilePage AddFilePage;
    protected CreateNewRepositoryPage CreateNewRepositoryPage;
    protected EditNewFilePage EditNewFilePage;
    protected HomePage HomePage;
    protected LoginPage LoginPage;
    protected MainPage MainPage;
    protected NewFilePage NewFilePage;
    protected RepositoryPage RepositoryPage;
    protected SettingPage SettingPage;
    
    public BaseStep(IWebDriver driver)
    {
        _driver = driver;
        AddFilePage = new AddFilePage(_driver);
        CreateNewRepositoryPage = new CreateNewRepositoryPage(_driver);
        EditNewFilePage = new EditNewFilePage(_driver);
        HomePage = new HomePage(_driver);
        LoginPage = new LoginPage(_driver);
        MainPage = new MainPage(_driver);
        NewFilePage = new NewFilePage(_driver);
        RepositoryPage = new RepositoryPage(_driver);
        SettingPage = new SettingPage(_driver);
    }
    
    protected IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}