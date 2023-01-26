using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Components;

public class BaseComponent
{
    protected AndroidDriver<AndroidElement> driver;

    protected BaseComponent(AndroidDriver<AndroidElement> driver)
    {
        this.driver = driver;
    }
}