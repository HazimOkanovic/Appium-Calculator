using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Pages;

public class SignInPage : BasePage
{
    private readonly By Title = MobileBy.Id("com.contextlogic.wish:id/title");
    
    public SignInPage(AndroidDriver<AndroidElement> driver) : base(driver)
    {
        
    }
    
    public string GetTitle()
    {
        return WaitElementVisibleAndGet(Title).Text;
    }
}