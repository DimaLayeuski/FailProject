using NetTestFramework.Pages;
using OpenQA.Selenium;

namespace NetTestFramework.Steps;

public class LoginStep: BaseStep
{
    
    public LoginStep(IWebDriver driver) : base(driver)
    {
        
    }
    
    public MainPage LoginWithUsernameAndPassword(string? username, string? password)
    {
        HomePage.OpenPage();
        HomePage.SignIn.Click();
        LoginPage.UsernameInput.SendKeys(username);
        LoginPage.PasswordInput.SendKeys(password);
        LoginPage.LoginButton.Click();
        return MainPage;
    }
}