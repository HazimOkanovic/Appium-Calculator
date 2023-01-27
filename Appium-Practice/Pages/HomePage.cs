using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Pages;

public class HomePage : BasePage
{
    private readonly By MenuButton = MobileBy.XPath("(//android.view.ViewGroup[5]//android.widget.ImageView)[2]");
    private readonly By NameTitle = MobileBy.Id("com.contextlogic.wish:id/menu_profile_name");
    private readonly By SettingsButton = MobileBy.Id("com.contextlogic.wish:id/menu_setting_view");
    
    public HomePage(AndroidDriver<AndroidElement> driver) : base(driver)
    {
    }
}