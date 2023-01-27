using Appium_Practice.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Components;

public class SingInModal : BasePage
{
    private readonly By ErrorMessage = MobileBy.Id("com.contextlogic.wish:id/multi_button_dialog_fragment_description");
    private readonly By OkButton = MobileBy.XPath("//android.widget.LinearLayout//android.widget.Button");
    
    public SingInModal(AndroidDriver<AndroidElement> driver) : base(driver)
    {
    }

    public string GetErrorMessage()
    {
        return WaitElementVisibleAndGet(ErrorMessage).Text;
    }

    public SignInPage ClickOk()
    {
        WaitElementVisibleAndGet(OkButton).Click();
        return new SignInPage(driver);
    }
}