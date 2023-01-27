using Appium_Practice.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Pages;

public class SettingsPage : BasePage
{
    public SignOutModal SignOutModal;
    
    private readonly By SettingsTitle = MobileBy.XPath("(//android.widget.LinearLayout//android.widget.TextView)[1]");
    private readonly By BackButton = MobileBy.XPath("//android.widget.ImageButton[@content-desc='Navigate up']");
    private readonly By AccountSettingsButton = MobileBy.Id("//android.widget.LinearLayout[3]//android.widget.TextView");
    private readonly By LogOutButton = MobileBy.Id("//android.widget.LinearLayout[5]//android.widget.TextView");
    private readonly By LogInButton = MobileBy.Id("//android.widget.LinearLayout[3]//android.widget.TextView");
    
    public SettingsPage(AndroidDriver<AndroidElement> driver) : base(driver)
    {
        SignOutModal = new SignOutModal(driver);
    }

    public string GetSettingsTitle()
    {
        return WaitElementVisibleAndGet(SettingsTitle).Text;
    }

    public SettingsPage ClickAccountSettings()
    {
        WaitElementVisibleAndGet(AccountSettingsButton).Click();
        return this;
    }

    public SignInPage ClickSignIn()
    {
        WaitElementVisibleAndGet(LogInButton).Click();
        return new SignInPage(driver);
    }
    
    public SignOutModal ClickLogOutButton()
    {
        WaitElementVisibleAndGet(LogOutButton).Click();
        return new SignOutModal(driver);
    }
    
    public HomePage ClickBackButton()
    {
        WaitElementVisibleAndGet(BackButton).Click();
        return new HomePage(driver);
    }
}