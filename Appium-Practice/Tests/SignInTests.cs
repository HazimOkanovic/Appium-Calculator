using Appium_Practice.Pages;

namespace Appium_Practice.Tests;

public class SignInTests : BaseTest
{
    private readonly HomePage homePage;
    private readonly SettingsPage settingsPage;
    private readonly SignInPage signInPage;
    private readonly SignUpPage signUpPage;

    public SignInTests()
    {
        homePage = new HomePage(driver);
        settingsPage = new SettingsPage(driver);
        signInPage = new SignInPage(driver);
        signUpPage = new SignUpPage(driver);
    }
}