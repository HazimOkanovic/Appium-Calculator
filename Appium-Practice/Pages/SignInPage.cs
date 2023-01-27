using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Pages;

public class SignInPage : BasePage
{
    private readonly By Title = MobileBy.Id("com.contextlogic.wish:id/title");
    private readonly By EmailInput = MobileBy.Id("com.contextlogic.wish:id/input");
    private readonly By PasswordInput = MobileBy.Id("com.contextlogic.wish:id/passwordText");
    private readonly By SignInButton = MobileBy.Id("com.contextlogic.wish:id/signInButton");
    private readonly By SignUpButton = MobileBy.Id("com.contextlogic.wish:id/createAccountButton");
    private readonly By CloseButton = MobileBy.Id("com.contextlogic.wish:id/closeButton");

    public SignInPage(AndroidDriver<AndroidElement> driver) : base(driver)
    {
    }
    
    public string GetTitle()
    {
        return WaitElementVisibleAndGet(Title).Text;
    }

    public SignInPage EnterEmail(string email)
    {
        WaitElementVisibleAndGet(EmailInput).SendKeys(email);
        return this;
    }
    
    public SignInPage EnterPassword(string password)
    {
        WaitElementVisibleAndGet(PasswordInput).SendKeys(password);
        return this;
    }

    public SignInPage ClickSignUpButton()
    {
        WaitElementVisibleAndGet(SignUpButton).Click();
        return this;
    }

    public HomePage ClickSignIn()
    {
        WaitElementVisibleAndGet(SignInButton).Click();
        return new HomePage(driver);
    }
    
    public HomePage ClickClose()
    {
        WaitElementVisibleAndGet(CloseButton).Click();
        return new HomePage(driver);
    }
}