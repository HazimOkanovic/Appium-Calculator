using Appium_Practice.Components;
using Appium_Practice.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Pages;

public class SignInPage : BasePage
{
    public SingInModal SignInModal { get; }
    
    private readonly By Title = MobileBy.Id("com.contextlogic.wish:id/title");
    private readonly By EmailInput = MobileBy.Id("com.contextlogic.wish:id/input");
    private readonly By PasswordInput = MobileBy.Id("com.contextlogic.wish:id/passwordText");
    private readonly By SignInButton = MobileBy.Id("com.contextlogic.wish:id/signInButton");
    private readonly By SignUpButton = MobileBy.Id("com.contextlogic.wish:id/createAccountButton");
    private readonly By CloseButton = MobileBy.Id("com.contextlogic.wish:id/closeButton");
    private readonly By WelcomeBackTitle = MobileBy.Id("com.contextlogic.wish:id/welcome_back_text");
    private readonly By SignInOtherAccountButton = MobileBy.Id("com.contextlogic.wish:id/other_account_button");

    public SignInPage(AndroidDriver<AndroidElement> driver) : base(driver)
    {
        SignInModal = new SingInModal(driver);
    }
    
    public string GetTitle()
    {
        return WaitElementVisibleAndGet(Title).Text;
    }
    
    public string GetWelcomeBackTitle()
    {
        return WaitElementVisibleAndGet(WelcomeBackTitle).Text;
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

    public SignInPage ClearEmail()
    {
        WaitElementVisibleAndGet(EmailInput).Clear();
        return this;
    }

    public SignInPage ClearPassword()
    {
        WaitElementVisibleAndGet(PasswordInput).Clear();
        return this;
    }
    
    public SignInPage ClickSignInOtherAccount()
    {
        WaitElementVisibleAndGet(SignInOtherAccountButton).Click();
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

    public SingInModal ClickSignInError()
    {
        WaitElementVisibleAndGet(SignInButton).Click();
        return new SingInModal(driver);
    }
    
    public HomePage ClickClose()
    {
        WaitElementVisibleAndGet(CloseButton).Click();
        return new HomePage(driver);
    }
}