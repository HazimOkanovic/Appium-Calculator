using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace Appium_Calculator.Helpers
{
    public class Configuration
    {
        public static AppiumOptions ReadConfiguration()
        {
            var desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.App, "C:/Users/hazim/Downloads/Sample/Sample-app.apk");
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            desiredCapabilities.AddAdditionalCapability("ignoreHiddenApiPolicyError", "true");
            desiredCapabilities.AddAdditionalCapability("allowTestPackages", "true");
            desiredCapabilities.AddAdditionalCapability("appWaitForLaunch", "false");
            return new AppiumOptions();
        }
    }
}