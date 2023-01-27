using Appium_Practice.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Components;

public class SignOutModal : BasePage
{
    private readonly By LogOutButton = MobileBy.XPath("//android.widget.LinearLayout//android.widget.Button");
    private readonly By XButton = MobileBy.Id("com.contextlogic.wish:id/multi_button_dialog_fragment_x_button");
    
    public SignOutModal(AndroidDriver<AndroidElement> driver) : base(driver)
    {
        
    }
}