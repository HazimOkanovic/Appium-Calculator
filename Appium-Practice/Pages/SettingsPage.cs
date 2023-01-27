using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Pages;

public class SettingsPage : BasePage
{
    private readonly By SettingsTitle = MobileBy.XPath("(//android.widget.LinearLayout//android.widget.TextView)[1]");
    private readonly By BackButton = MobileBy.XPath("//android.widget.ImageButton[@content-desc='Navigate up']");
    private readonly By AccountSettingsButton = MobileBy.Id("//android.widget.LinearLayout[3]//android.widget.TextView");
    private readonly By LogOutButton = MobileBy.Id("//android.widget.LinearLayout[5]//android.widget.TextView");
    
    public SettingsPage(AndroidDriver<AndroidElement> driver) : base(driver)
    {
    }
}